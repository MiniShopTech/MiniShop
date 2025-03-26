using MayNghien.Infrastructure.Models.Entity;
using MiniShop.Commons.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniShop.Models.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Address Address { get; set; }

        [ForeignKey("Category")]
        public Guid? CategoryId { get; set; }
        public Category? Category { get; set; }

        //[ForeignKey("Tenant")]
        //public Guid? TenantId { get; set; }
        //public Tenant? Tenant { get; set; }

        public ICollection<Cart>? Carts { get; set; }
        public ICollection<Review>? Reviews { get; set; }
        public ICollection<Variant>? Variants { get; set; }
        public ICollection<InvoiceDetail>? InvoiceDetails { get; set; }
    }
}
