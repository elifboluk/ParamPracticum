using Microsoft.EntityFrameworkCore;
using Practicum.Core.Entities;
using Practicum.Core.Repositories;
using Practicum.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicum.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Product> GetByNameAsync(string name)
        {
            return await _context.Products.Where(x => x.ProductName == name).SingleOrDefaultAsync();
        }
    }
}
