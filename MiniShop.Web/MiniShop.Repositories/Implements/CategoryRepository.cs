using Maynghien.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using MiniShop.Models.Data;
using MiniShop.Models.Entities;
using MiniShop.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniShop.Repositories.Implements
{
    public class CategoryRepository : GenericRepository<Category, ApplicationDbContext, ApplicationUser>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<List<Category>> GetAllAsync()
        {
            var categories = await _context.Categories.Where(category => category.IsDeleted == false).ToListAsync();
            return categories;
        }
    }
}
