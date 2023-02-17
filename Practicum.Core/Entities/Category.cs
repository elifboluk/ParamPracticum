using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicum.Core.Entities
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
    }
}
