using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicum.Core.DTOs
{
    public class CategoryDto : BaseDto
    {
        public string CategoryName { get; set; }
        public int CompanyId { get; set; }
    }
}
