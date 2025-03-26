using MayNghien.Infrastructure.Request.Base;
using MayNghien.Models.Response.Base;
using Microsoft.AspNetCore.Mvc;
using MiniShop.DTOs.Requests;
using MiniShop.DTOs.Responses;
using MiniShop.Services.Interfaces;
using System.Threading.Tasks;

namespace MiniShop.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index(string search)
        {
            var result = await _categoryService.GetAllAsync();
            if (!string.IsNullOrEmpty(search))
                result.Data = result.Data
                    .Where(c => c.Name.Contains(search, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _categoryService.CreateAsync(request);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View(request);
            }
            TempData["SuccessMessage"] = "Category created successfully.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Detail(Guid id)
        {
            var result = await _categoryService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return RedirectToAction("Index");
            }
            return View(result.Data);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _categoryService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                TempData["ErrorMessage"] = result.Message;
                return RedirectToAction("Index");
            }

            var categoryRequest = new CategoryRequest
            {
                Id = result.Data.Id,
                Name = result.Data.Name,
                Description = result.Data.Description,
                IsPresent = result.Data.IsPresent
            };
            return View(categoryRequest);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(CategoryRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _categoryService.UpdateAsync(request);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View(request);
            }
            TempData["SuccessMessage"] = "Category updated successfully.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
                return NotFound();
            var result = await _categoryService.GetByIdAsync(id.Value);
            if (!result.IsSuccess || result.Data == null)
                return NotFound();
            return View(result.Data);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var result = await _categoryService.DeleteAsync(id);
            if (!result.IsSuccess)
            {
                TempData["ErrorMessage"] = result.Message;
                return RedirectToAction("Index");
            }
            TempData["SuccessMessage"] = "Category deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}
