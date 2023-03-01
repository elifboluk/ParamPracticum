using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Practicum.API.Controllers;
using Practicum.Core.DTOs;
using Practicum.Core.Entities;
using Practicum.Core.Services;

namespace Practicum.Test
{
    public class CategoryApiControllerTest
    {
        private readonly Mock<ICategoryService> _categoryServiceMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly CategoryController _categoryController;

        public CategoryApiControllerTest()
        {
            _categoryServiceMock = new Mock<ICategoryService>();
            _mapperMock = new Mock<IMapper>();
            _categoryController = new CategoryController(_mapperMock.Object, _categoryServiceMock.Object);
        }
      
        [Fact] // OK!
        public async void All_ReturnsOkResult_WhenCategoryExists()
        {
            // Arrange
            var categories = CreateCategoryList();
            var dtoExpected = MapModelToCategoryResultListDto(categories.ToList()); // Return Dto

            // Act
            _categoryServiceMock.Setup(x => x.GetAllAsync()).ReturnsAsync(categories);
            _mapperMock.Setup(y => y.Map<IEnumerable<CategoryDto>>(It.IsAny<List<Category>>())).Returns(dtoExpected);
            var result = await _categoryController.All();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact] // OK!
        public async void GetById_ReturnsOkResult_WhenCategoryExists()
        {
            var category = CreateCategory();
            var dtoExpected = MapModelToCategoryResultDto(category);

            _categoryServiceMock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(category);
            _mapperMock.Setup(y => y.Map<CategoryDto>(category)).Returns(dtoExpected);
            var result = await _categoryController.GetById(1);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact] // OK!
        public async void GetById_ReturnsNotFoundResult_WhenCategoryDoesNotExist()
        {
            // Arrange
            _categoryServiceMock.Setup(x => x.GetByIdAsync(20)).ReturnsAsync((Category)null!);

            // Act
            var result = await _categoryController.GetById(20);

            // Assert
            Assert.IsType<NotFoundResult>(result);            
        }

        [Fact] // OK!
        public async void Save_ReturnsOkResult_WhenModelStateValid()
        {
            var category = CreateCategory();
            var dtoExpected = MapModelToCategoryResultDto(category);

            _categoryServiceMock.Setup(x => x.AddAsync(It.IsAny<Category>())).ReturnsAsync(category);

            var result = await _categoryController.Save(dtoExpected);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact] // OK!
        public async void Update_ReturnsOkResult_WithMatchingIdAndCategoryDto()
        {
            // Arrange
            var category = CreateCategory();
            category.CategoryName = "Test_Category_Name";
            var dtoExpected = MapModelToCategoryResultDto(category);

            // Act
            _categoryServiceMock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(category);
            _mapperMock.Setup(y => y.Map<Category>(dtoExpected)).Returns(category);
            var result = await _categoryController.Update(dtoExpected);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact] // OK!
        public async void Update_ReturnsNotFound_WhenCategoryNotExists()
        {
            _categoryServiceMock.Setup(x => x.UpdateAsync(It.IsAny<Category>())).Throws(new Exception("Category is not found"));

            var result = await _categoryController.GetById(20);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact] // OK!
        public async void Remove_ReturnsOkResult_WhenCategoryRemoved()
        {
            // Arrange
            var category = CreateCategory();
            var dtoExpected = MapModelToCategoryResultDto(category);

            // Act
            _categoryServiceMock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(category);
            _mapperMock.Setup(y => y.Map<Category>(dtoExpected)).Returns(category);
            var result = await _categoryController.Remove(1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        public IEnumerable<Category> CreateCategoryList()
        {
            return new List<Category>
            {
                new Category
                {
                    Id = 1,
                    CompanyId = 1,
                    CategoryName = "Category Test 1"                    
                },
                new Category
                {
                    Id = 2,
                    CompanyId = 1,
                    CategoryName = "Category Test 2"
                }
            };
        }
        public IEnumerable<CategoryDto> MapModelToCategoryResultListDto(List<Category> categories)
        {
            var listCategory = new List<CategoryDto>();
            foreach (var item in categories)
            {
                var category = new CategoryDto
                {
                    Id = item.Id,
                    CompanyId = item.CompanyId,
                    CategoryName = item.CategoryName
                };
                listCategory.Add(category);
            }
            return listCategory;
        }
        public Category CreateCategory()
        {
            return new Category
            {
                Id = 1,
                CompanyId = 1,
                CategoryName = "Category Tester 1"
            };
        }
        public CategoryDto MapModelToCategoryResultDto(Category category)
        {
            var categoryDto = new CategoryDto
            {
                Id = category.Id,
                CompanyId = category.CompanyId,
                CategoryName = category.CategoryName                
            };
            return categoryDto;
        }
    }
}
