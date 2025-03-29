using AutoMapper;
using LinqKit;
using MayNghien.Infrastructure.Request.Base;
using MayNghien.Models.Response.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MiniShop.DTOs.Requests;
using MiniShop.DTOs.Responses;
using MiniShop.Models.Entities;
using MiniShop.Repositories.Interfaces;
using MiniShop.Services.Interfaces;
using static Maynghien.Infrastructure.Helpers.SearchHelper;

namespace MiniShop.Services.Implements
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<AppResponse<List<CategoryResponse>>> GetAllAsync()
        {
            var result = new AppResponse<List<CategoryResponse>>();
            try
            {
                var categories = await _categoryRepository.GetAllAsync();
                if (categories == null || !categories.Any())
                    return result.BuildError("No categories found.");

                var response = _mapper.Map<List<CategoryResponse>>(categories);
                result.BuildResult(response);
            }
            catch (Exception ex)
            {
                result.BuildError(ex.Message + " " + ex.StackTrace);
            }
            return result;
        }

        public async Task<AppResponse<CategoryResponse>> CreateAsync(CategoryRequest request)
        {
            var result = new AppResponse<CategoryResponse>();
            try
            {
                var newCategory = _mapper.Map<Category>(request);
                newCategory.Id = Guid.NewGuid();
                newCategory.Name = request.Name;
                newCategory.Description = request.Description;
                newCategory.IsPresent = request.IsPresent;
                newCategory.CreatedOn = DateTime.UtcNow;
                await _categoryRepository.AddAsync(newCategory);

                var response = _mapper.Map<CategoryResponse>(newCategory);
                result.BuildResult(response, "Product created successfully");
            }
            catch (Exception ex)
            {
                result.BuildError(ex.Message + " " + ex.StackTrace);
            }
            return result;
        }

        public async Task<AppResponse<CategoryResponse>> GetByIdAsync(Guid id)
        {
            var result = new AppResponse<CategoryResponse>();
            try
            {
                var category = await _categoryRepository.GetAsync(id);
                if (category == null)
                    return result.BuildError("Category not found or deleted");

                var data = new CategoryResponse
                {
                    Id = id,
                    Name = category.Name,
                    Description = category.Description,
                    IsPresent = true,
                    Products = _productRepository.FindByAsync(x => x.CategoryId == category.Id)
                    .Select(x => new ProductResponse
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = x.Description,
                        Price = x.Price,
                        Quantity = x.Quantity,
                        Address = x.Address,
                        CategoryId = category.Id,
                        CategoryName = category.Name,
                    }).ToList()
                };
                result.BuildResult(data);
            }
            catch (Exception ex)
            {
                result.BuildError(ex.Message + " " + ex.StackTrace);
            }
            return result;
        }

        public async Task<AppResponse<CategoryResponse>> UpdateAsync(CategoryRequest request)
        {
            var result = new AppResponse<CategoryResponse>();
            try
            {
                var category = await _categoryRepository.GetAsync(request.Id!.Value);
                if (category == null || category.IsDeleted == true)
                    return result.BuildError("Category not found or deleted");

                category.Name = request.Name;
                category.Description = request.Description;
                category.IsPresent = request.IsPresent;
                category.ModifiedOn = DateTime.UtcNow;
                await _categoryRepository.EditAsync(category);

                var response = _mapper.Map<CategoryResponse>(category);
                response.Products = _productRepository.FindByAsync(x => x.CategoryId == category.Id)
                    .Select(x => new ProductResponse
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = x.Description,
                        Price = x.Price,
                        Quantity = x.Quantity,
                        Address = x.Address,
                        CategoryId = category.Id,
                        CategoryName = category.Name,
                    }).ToList();
                result.BuildResult(response, "Category updated successfully");
            }
            catch (Exception ex)
            {
                result.BuildError(ex.Message + " " + ex.StackTrace);
            }
            return result;
        }

        public async Task<AppResponse<string>> DeleteAsync(Guid id)
        {
            var result = new AppResponse<string>();
            try
            {
                var category = await _categoryRepository.GetAsync(id);
                if (category == null)
                    result.BuildError("Category not found");
                category!.IsDeleted = true;
                await _categoryRepository.EditAsync(category);
                result.BuildResult("Category deleted successfully");
            }
            catch (Exception ex)
            {
                result.BuildError(ex.Message + " " + ex.StackTrace);
            }
            return result;
        }

        public async Task<AppResponse<SearchResponse<CategoryResponse>>> SearchAsync(SearchRequest request)
        {
            var result = new AppResponse<SearchResponse<CategoryResponse>>();
            try
            {
                var query = BuildFilterExpression(request.Filters!);
                var numOfRecords = await _categoryRepository.CountRecordsAsync(query);
                var categories = _categoryRepository.FindByPredicate(query).Include(x => x.Products).AsQueryable();
                if (request.SortBy != null)
                    categories = _categoryRepository.addSort(categories, request.SortBy);
                else
                    categories = categories.OrderBy(x => x.Name);

                int pageIndex = request.PageIndex ?? 1;
                int pageSize = request.PageSize ?? 1;
                int startIndex = (pageIndex - 1) * pageSize;
                var categoryList = await categories.Skip(startIndex).Take(pageSize).ToListAsync();
                var dtoList = _mapper.Map<List<CategoryResponse>>(categoryList);
                var searchResponse = new SearchResponse<CategoryResponse>
                {
                    TotalRows = numOfRecords,
                    TotalPages = CalculateNumOfPages(numOfRecords, pageSize),
                    CurrentPage = pageIndex,
                    Data = dtoList,
                    RowsPerPage = pageSize
                };
                result.Data = searchResponse;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.BuildError(ex.Message + " " + ex.StackTrace);
            }
            return result;
        }

        private ExpressionStarter<Category> BuildFilterExpression(List<Filter> filters)
        {
            try
            {
                var predicate = PredicateBuilder.New<Category>(true);
                if (filters != null)
                {
                    foreach (var filter in filters)
                    {
                        switch (filter.FieldName)
                        {
                            case "Name":
                                predicate = predicate.And(x => x.Name.Contains(filter.Value));
                                break;
                            case "IsPresent":
                                predicate = predicate.And(x => x.IsPresent == bool.Parse(filter.Value));
                                break;
                            default:
                                break;
                        }
                    }
                }

                predicate = predicate.And(x => x.IsDeleted == false);
                return predicate;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " " + ex.StackTrace);
            }
        }
    }
}
