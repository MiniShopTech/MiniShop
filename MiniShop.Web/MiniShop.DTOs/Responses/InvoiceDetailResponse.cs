using MayNghien.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniShop.DTOs.Responses
{
    public class InvoiceDetailResponse : BaseDto
    {
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public Guid? OrderId { get; set; }
        public Guid? ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
