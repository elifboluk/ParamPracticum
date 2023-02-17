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
    public class CompanyService : Service<Company>, ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(IGenericRepository<Company> repository, IUnitOfWork unitOfWork, IMapper mapper, ICompanyRepository companyRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _companyRepository = companyRepository;
        }

        public async Task<CustomResponseDto<CompanyWithProductsDto>> GetSingleCompanyByIdWithProductsAsync(int companyId)
        {
            var hascompany = await _companyRepository.GetSingleCompanyByIdWithProductsAsync(companyId);
            if (hascompany == null)
            {
                throw new NotFoundException($"{typeof(Company).Name}({companyId}) not found.");
            }
            var companyDto = _mapper.Map<CompanyWithProductsDto>(hascompany);
            return CustomResponseDto<CompanyWithProductsDto>.Success(200, companyDto);
        }
    }
}
