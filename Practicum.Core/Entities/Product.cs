using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicum.Core.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}
