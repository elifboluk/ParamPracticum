using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicum.Core.Entities
{
    public class Company : BaseEntity
    {
        public string CompanyName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
