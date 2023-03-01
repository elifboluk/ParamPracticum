using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Practicum.API.Controllers;
using Practicum.Core.DTOs;
using Practicum.Core.Entities;
using Practicum.Core.Services;

namespace Practicum.Test
{
    public class CompanyApiControllerTest
    {
        private readonly Mock<ICompanyService> _companyServiceMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly CompanyController _companyController;

        public CompanyApiControllerTest()
        {
            _companyServiceMock = new Mock<ICompanyService>();
            _mapperMock = new Mock<IMapper>();
            _companyController = new CompanyController(_mapperMock.Object, _companyServiceMock.Object);
        }
       
        [Fact] // OK!
        public async void All_ReturnsOkResult_WhenCompanyExists()
        {
            // Arrange
            var companies = CreateCompanyList();
            var dtoExpected = MapModelToCompanyResultListDto(companies.ToList()); // Return Dto

            // Act
            _companyServiceMock.Setup(x => x.GetAllAsync()).ReturnsAsync(companies);
            _mapperMock.Setup(y => y.Map<IEnumerable<CompanyDto>>(It.IsAny<List<Company>>())).Returns(dtoExpected);
            var result = await _companyController.All();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact] // OK!
        public async void GetById_ReturnsOkResult_WhenCompanyExists()
        {
            var company = CreateCompany();
            var dtoExpected = MapModelToCompanyResultDto(company);

            _companyServiceMock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(company);
            _mapperMock.Setup(y => y.Map<CompanyDto>(company)).Returns(dtoExpected);
            var result = await _companyController.GetById(1);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact] // OK!
        public async void GetById_ReturnsNotFoundResult_WhenCompanyDoesNotExist()
        {
            // Arrange
            _companyServiceMock.Setup(x => x.GetByIdAsync(20)).ReturnsAsync((Company)null!);

            // Act
            var result = await _companyController.GetById(20);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact] // OK!
        public async void Save_ReturnsOkResult_WhenModelStateValid()
        {
            var company = CreateCompany();
            var dtoExpected = MapModelToCompanyResultDto(company);

            _companyServiceMock.Setup(x => x.AddAsync(It.IsAny<Company>())).ReturnsAsync(company);

            var result = await _companyController.Save(dtoExpected);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact] // OK!
        public async void Update_ReturnsOkResult_WithMatchingIdAndCompanyDto()
        {
            // Arrange
            var company = CreateCompany();
            company.CompanyName = "Test_Company_Name";
            var dtoExpected = MapModelToCompanyResultDto(company);

            // Act
            _companyServiceMock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(company);
            _mapperMock.Setup(y => y.Map<Company>(dtoExpected)).Returns(company);
            var result = await _companyController.Update(dtoExpected);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact] // OK!
        public async void Update_ReturnsNotFound_WhenCompanyNotExists()
        {
            _companyServiceMock.Setup(x => x.UpdateAsync(It.IsAny<Company>())).Throws(new Exception("Company is not found"));

            var result = await _companyController.GetById(20);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact] // OK!
        public async void Remove_ReturnsOkResult_WhenCompanyRemoved()
        {
            // Arrange
            var company = CreateCompany();
            var dtoExpected = MapModelToCompanyResultDto(company);

            // Act
            _companyServiceMock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(company);
            _mapperMock.Setup(y => y.Map<Company>(dtoExpected)).Returns(company);
            var result = await _companyController.Remove(1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        public IEnumerable<Company> CreateCompanyList()
        {
            return new List<Company>
            {
                new Company
                {
                    Id = 1,                    
                    CompanyName = "Company Test 1"
                },
                new Company
                {
                    Id = 2,
                    CompanyName = "Company Test 2"
                }
            };
        }
        public IEnumerable<CompanyDto> MapModelToCompanyResultListDto(List<Company> companies)
        {
            var listCompany = new List<CompanyDto>();
            foreach (var item in companies)
            {
                var company = new CompanyDto
                {
                    Id = item.Id, 
                    CompanyName = item.CompanyName                    
                };
                listCompany.Add(company);
            }
            return listCompany;
        }
        public Company CreateCompany()
        {
            return new Company
            {
                Id = 1,
                CompanyName = "Company Tester 1"
            };
        }
        public CompanyDto MapModelToCompanyResultDto(Company company)
        {
            var companyDto = new CompanyDto
            {
                Id = company.Id,
                CompanyName = company.CompanyName
            };
            return companyDto;
        }
    }
}
