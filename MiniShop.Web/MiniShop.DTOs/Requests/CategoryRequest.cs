using MayNghien.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniShop.DTOs.Requests
{
    public class CategoryRequest : BaseDto
    {
        [Required(ErrorMessage = "Category name is required")]
        [StringLength(100, ErrorMessage = "Category name must not exceed 100 characters")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "Description must not exceed 500 characters")]
        public string Description { get; set; }

        public bool IsPresent { get; set; }
    }
}
