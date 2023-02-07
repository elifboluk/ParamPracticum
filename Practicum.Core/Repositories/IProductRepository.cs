using Practicum.Core.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicum.Core.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<Product> GetByNameAsync(string name);
    }
}
