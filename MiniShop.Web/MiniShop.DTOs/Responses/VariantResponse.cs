using MayNghien.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniShop.DTOs.Responses
{
    public class VariantResponse : BaseDto
    {
        public string? Type { get; set; }
        public decimal Price { get; set; }
        public Guid? ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
