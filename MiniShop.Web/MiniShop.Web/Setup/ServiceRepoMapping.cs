using MiniShop.Repositories.Implements;
using MiniShop.Repositories.Interfaces;
using MiniShop.Services.Implements;
using MiniShop.Services.Interfaces;

namespace MiniShop.Web.Setup
{
    public class ServiceRepoMapping
    {
        public void Mapping(WebApplicationBuilder builder)
        {
            #region Respositories
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            #endregion

            #region Services
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            #endregion
        }
    }
}
