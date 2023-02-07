using AutoMapper;
using Practicum.Core.DTOs;
using Practicum.Core.Entities;
using Practicum.Core.Repositories;
using Practicum.Core.Services;
using Practicum.Core.UnitOfWorks;
using Practicum.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicum.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IMapper mapper, IProductRepository productService) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _productRepository = productService;
        }

        public async Task<CustomResponseDto<ProductDto>> GetByNameAsync(string name)
        {
            var hasProduct = await _productRepository.GetByNameAsync(name);
            if (hasProduct == null)
            {
                throw new NotFoundException($"{typeof(Product).Name}({name}) not found.");
            }
            var productDto = _mapper.Map<ProductDto>(hasProduct);
            return CustomResponseDto<ProductDto>.Success(200, productDto);
        }
    }
}
