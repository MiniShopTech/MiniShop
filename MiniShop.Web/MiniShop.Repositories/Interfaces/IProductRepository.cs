using Maynghien.Infrastructure.Repository;
using MiniShop.Models.Data;
using MiniShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniShop.Repositories.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product, ApplicationDbContext, ApplicationUser>
    {
    }
}
