using MayNghien.Infrastructure.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniShop.Models.Entities
{
    public class InvoiceDetail : BaseEntity
    {
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }

        //[ForeignKey("Invoice")]
        //public Guid? InvoiceId { get; set; }
        //public Invoice? Invoice { get; set; }

        [ForeignKey("Product")]
        public Guid? ProductId { get; set; }
        public string ProductName { get; set; }
        public Product? Product { get; set; }
    }
}
