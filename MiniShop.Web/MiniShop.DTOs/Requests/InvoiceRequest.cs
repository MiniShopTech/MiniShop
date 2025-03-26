using MayNghien.Infrastructure.Models;
using MiniShop.Commons.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MiniShop.DTOs.Requests
{
    public class InvoiceRequest : BaseDto
    {
        [Required(ErrorMessage = "Status is required")]
        public Status Status { get; set; }

        [Required(ErrorMessage = "Product address is required")]
        public Address ProductAddress { get; set; }

        [Required(ErrorMessage = "Shipping address is required")]
        [StringLength(500, ErrorMessage = "Shipping address must not exceed 500 characters")]
        public string ShippingAddress { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Shipping fee must be a non-negative value")]
        public double ShippingFee { get; set; }

        public List<Guid>? CartIds { get; set; }
    }
}
