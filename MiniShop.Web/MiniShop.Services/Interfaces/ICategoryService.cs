using MayNghien.Infrastructure.Request.Base;
using MayNghien.Models.Response.Base;
using MiniShop.DTOs.Requests;
using MiniShop.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniShop.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<AppResponse<List<CategoryResponse>>> GetAllAsync();
        Task<AppResponse<CategoryResponse>> CreateAsync(CategoryRequest request);
        Task<AppResponse<CategoryResponse>> GetByIdAsync(Guid id);
        Task<AppResponse<CategoryResponse>> UpdateAsync(CategoryRequest request);
        Task<AppResponse<string>> DeleteAsync(Guid id);
        Task<AppResponse<SearchResponse<CategoryResponse>>> SearchAsync(SearchRequest request);
    }
}
