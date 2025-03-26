using MayNghien.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MiniShop.DTOs.Requests
{
    public class InvoiceDetailRequest : BaseDto
    {
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be at least 0")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "OrderId is required")]
        public Guid? OrderId { get; set; }

        [Required(ErrorMessage = "ProductId is required")]
        public Guid? ProductId { get; set; }
    }
}
