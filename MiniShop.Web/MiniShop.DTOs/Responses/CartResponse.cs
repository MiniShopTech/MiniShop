using MayNghien.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniShop.DTOs.Responses
{
    public class CartResponse : BaseDto
    {
        public int Quantity { get; set; }
        public string Type { get; set; }
        public decimal TotalAmount { get; set; }
        public Guid? ProductId { get; set; }
        public string ProductName { get; set; }
        public Guid? VariantId { get; set; }
        public string VariantName { get; set; }

        public List<ProductResponse>? Products { get; set; }
    }
}
