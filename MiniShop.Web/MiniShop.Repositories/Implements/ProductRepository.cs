using Maynghien.Infrastructure.Repository;
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
    public class ProductRepository : GenericRepository<Product, ApplicationDbContext, ApplicationUser>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext unitOfWork) : base(unitOfWork)
        {
        }
    }
}
