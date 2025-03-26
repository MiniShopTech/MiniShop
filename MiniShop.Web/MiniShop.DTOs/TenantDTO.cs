using MayNghien.Infrastructure.Models;
using MiniShop.Commons.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniShop.DTOs
{
    public class TenantDTO : BaseDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name must not exceed 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Type is required")]
        public TenantTypes Type { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number format")]
        public string PhoneNumber { get; set; }
    }
}
