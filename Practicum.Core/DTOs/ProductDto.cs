using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicum.Core.DTOs
{
    public class ProductDto : BaseDto
    {
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CompanyId { get; set; }
        public int CategoryId { get; set; }
    }
}
