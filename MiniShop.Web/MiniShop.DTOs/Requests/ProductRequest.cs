using MayNghien.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using MiniShop.Commons.Enums;
using System.ComponentModel.DataAnnotations;

public class ProductRequest : BaseDto
{
    [Required(ErrorMessage = "Product name is required")]
    [StringLength(100, ErrorMessage = "Product name must not exceed 100 characters")]
    public string Name { get; set; }

    [StringLength(500, ErrorMessage = "Description must not exceed 500 characters")]
    public string Description { get; set; }

    [Precision(18, 2)]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
    public decimal Price { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Quantity must be at least 0")]
    public int Quantity { get; set; }

    [Required(ErrorMessage = "Address is required")]
    public Address Address { get; set; }

    public Guid? CategoryId { get; set; }
}
