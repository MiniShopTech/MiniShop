using MayNghien.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniShop.DTOs.Requests
{
    public class CartRequest : BaseDto
    {
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be at least 0")]
        public int Quantity { get; set; }

        [StringLength(100, ErrorMessage = "Type must not exceed 100 characters")]
        public string Type { get; set; }

        [Required(ErrorMessage = "ProductId is required")]
        public Guid? ProductId { get; set; }

        [Required(ErrorMessage = "VariantId is required")]
        public Guid? VariantId { get; set; }
    }
}
