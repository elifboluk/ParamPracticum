using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Practicum.Core.DTOs;
using Practicum.Core.Entities;
using Practicum.Core.Services;

namespace Practicum.API.Controllers
{
    public class CompanyController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ICompanyService _service;

        public CompanyController(IMapper mapper, ICompanyService service)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("[action]/{companyId}")]
        public async Task<IActionResult> GetSingleCompanyByIdWithProducts(int companyId)
        {
            return Ok(await _service.GetSingleCompanyByIdWithProductsAsync(companyId));
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var companies = await _service.GetAllAsync();
            var companiesDtos = _mapper.Map<List<CompanyDto>>(companies.ToList());
            return Ok(CustomResponseDto<List<CompanyDto>>.Success(200, companiesDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var companies = await _service.GetByIdAsync(id);
            if (companies == null)
                return NotFound();
            var companiesDtos = _mapper.Map<CompanyDto>(companies);
            return Ok(CustomResponseDto<CompanyDto>.Success(200, companiesDtos));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CompanyDto companyDto)
        {
            var company = await _service.AddAsync(_mapper.Map<Company>(companyDto));
            var companyDtos = _mapper.Map<CompanyDto>(company);
            return Ok(CustomResponseDto<CompanyDto>.Success(201, companyDtos));
        }

        [HttpPut]
        public async Task<IActionResult> Update(CompanyDto companyDto)
        {
            await _service.UpdateAsync(_mapper.Map<Company>(companyDto));
            return Ok(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var company = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(company);
            return Ok(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
