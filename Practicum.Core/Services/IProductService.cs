using Practicum.Core.DTOs;
using Practicum.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicum.Core.Services
{
    public interface IProductService : IService<Product>
    {
        public Task<CustomResponseDto<ProductDto>> GetByNameAsync(string name);
    }
}
