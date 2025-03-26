using MayNghien.Infrastructure.Models;
using MiniShop.Commons.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniShop.DTOs.Responses
{
    public class ReviewResponse : BaseDto
    {
        public Guid? ProductId { get; set; }
        public string ProductName { get; set; }
        public Ratings Rating { get; set; }
        public string? Comment { get; set; }
    }
}
