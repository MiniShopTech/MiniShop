using MayNghien.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniShop.DTOs.Responses
{
    public class StaffResponse : BaseDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
