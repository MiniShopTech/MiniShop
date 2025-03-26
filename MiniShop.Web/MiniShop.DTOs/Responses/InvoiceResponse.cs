using MayNghien.Infrastructure.Models;
using MiniShop.Commons.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniShop.DTOs.Responses
{
    public class InvoiceResponse : BaseDto
    {
        public decimal TotalAmount { get; set; }
        public Status Status { get; set; }
        public Address ProductAddress { get; set; }
        public string ShippingAddress { get; set; }
        public ShippingMethod ShippingMethod { get; set; }
        public double ShippingFee { get; set; }

        public List<InvoiceDetailResponse>? InvoiceDetails { get; set; }
    }
}
