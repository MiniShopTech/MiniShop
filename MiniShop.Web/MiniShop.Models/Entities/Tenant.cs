using MayNghien.Infrastructure.Models.Entity;
using MiniShop.Commons.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniShop.Models.Entities
{
    public class Tenant : BaseEntity
    {
        public string Name { get; set; }
        public TenantTypes Type { get; set; }
        public Genders Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        //public ICollection<Category>? Categories { get; set; }
        //public ICollection<Product>? Products { get; set; }
        //public ICollection<Staff>? Staff { get; set; }
    }
}
