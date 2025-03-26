using MayNghien.Infrastructure.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace MiniShop.DTOs.Requests
{
    public class VariantRequest : BaseDto
    {
        [Required(ErrorMessage = "Type is required")]
        [StringLength(100, ErrorMessage = "Type must not exceed 100 characters")]
        public string? Type { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "ProductId is required")]
        public Guid? ProductId { get; set; }
    }
}
