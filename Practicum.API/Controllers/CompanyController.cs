using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Practicum.Core.DTOs;
using Practicum.Core.Entities;
using Practicum.Core.Services;

namespace Practicum.API.Controllers
{
    public class CompanyController : CustomBaseController
    {
        private readonly ICompanyService _service;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("[action]/{companyId}")]
        public async Task<IActionResult> GetSingleCompanyByIdWithProducts(int companyId)
        {
            return CreateActionResult(await _service.GetSingleCompanyByIdWithProductsAsync(companyId));
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var companies = await _service.GetAllAsync();
            var companiesDtos = _mapper.Map<List<CompanyDto>>(companies.ToList());
            return CreateActionResult(CustomResponseDto<List<CompanyDto>>.Success(200, companiesDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var companies = await _service.GetByIdAsync(id);
            var companiesDtos = _mapper.Map<CompanyDto>(companies);
            return CreateActionResult(CustomResponseDto<CompanyDto>.Success(200, companiesDtos));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CompanyDto companyDto)
        {
            var company = await _service.AddAsync(_mapper.Map<Company>(companyDto));
            var companyDtos = _mapper.Map<CompanyDto>(company);
            return CreateActionResult(CustomResponseDto<CompanyDto>.Success(201, companyDtos));
        }

        [HttpPut]
        public async Task<IActionResult> Update(CompanyDto companyDto)
        {
            await _service.UpdateAsync(_mapper.Map<Company>(companyDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var company = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(company);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
