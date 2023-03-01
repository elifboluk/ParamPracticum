using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Practicum.Core.DTOs;
using Practicum.Core.Entities;
using Practicum.Core.Services;

namespace Practicum.API.Controllers
{
    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductService _service;
        //IService<Product> service, 

        public ProductsController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _service = productService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await _service.GetAllAsync();
            var productsDtos = _mapper.Map<List<ProductDto>>(products.ToList());
            return Ok(CustomResponseDto<List<ProductDto>>.Success(200, productsDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            if (product == null)
                return NotFound();
            var productsDtos = _mapper.Map<ProductDto>(product);
            return Ok(CustomResponseDto<ProductDto>.Success(200, productsDtos));
        }

        [HttpGet("[action]/{name}")]
        public async Task<IActionResult> GetByNameAsync(string name)
        {
            return Ok(await _service.GetByNameAsync(name));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var product = await _service.AddAsync(_mapper.Map<Product>(productDto));
            var productsDtos = _mapper.Map<ProductDto>(product);
            return Ok(CustomResponseDto<ProductDto>.Success(201, productsDtos));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
            await _service.UpdateAsync(_mapper.Map<Product>(productDto));
            return Ok(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _service.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            await _service.RemoveAsync(product);
            return Ok(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
