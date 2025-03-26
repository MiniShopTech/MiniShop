using MayNghien.Infrastructure.Models.Entity;
using MiniShop.Commons.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MiniShop.Models.Entities
{
    public class Invoice : BaseEntity
    {
        public decimal TotalAmount { get; set; }
        public Status Status { get; set; }
        public Address ProductAddress { get; set; }
        public string ShippingAddress { get; set; }
        public ShippingMethod ShippingMethod { get; set; }
        public double ShippingFee { get; set; }

        //[ForeignKey("Tenant")]
        //public Guid? TenantId { get; set; }
        //public Tenant? Tenant { get; set; }

        public ICollection<InvoiceDetail>? InvoiceDetails { get; set; }
    }
}
