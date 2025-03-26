using MayNghien.Infrastructure.Models;
using MiniShop.Commons.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace MiniShop.DTOs.Requests
{
    public class ReviewRequest : BaseDto
    {
        [Required(ErrorMessage = "Rating is required")]
        public Ratings Rating { get; set; }

        [StringLength(500, ErrorMessage = "Comment must not exceed 500 characters")]
        public string? Comment { get; set; }

        [Required(ErrorMessage = "ProductId is required")]
        public Guid? ProductId { get; set; }
    }
}
