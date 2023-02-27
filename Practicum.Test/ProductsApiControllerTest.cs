using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Practicum.API.Controllers;
using Practicum.Core.DTOs;
using Practicum.Core.Entities;
using Practicum.Core.Services;
using System.ComponentModel.Design;

namespace Practicum.Test
{
    public class ProductsApiControllerTest : CustomBaseController
    {
        private readonly ProductsController _productsController;
        private readonly Mock<IProductService> _productServiceMock;
        private readonly Mock<IMapper> _mapperMock;

        // You don't have to write in ctor.
        public ProductsApiControllerTest()
        {            
            _productServiceMock = new Mock<IProductService>();
            _mapperMock = new Mock<IMapper>();
            _productsController = new ProductsController(_mapperMock.Object, _productServiceMock.Object);
        }

        [Fact]
        public async void All_ShouldReturnCreateActionResultSucces_WhenExistProduct()
        {
            // Arrange
            var products = CreateProductList(); // Product List
            var dtoExpected = MapModelToProductResultListDto(products); // Return Dto

            // Act
            _productServiceMock.Setup(x => x.GetAllAsync()).ReturnsAsync(products);
            _mapperMock.Setup(x => x.Map<IEnumerable<ProductDto>>(It.IsAny<List<Product>>())).Returns(dtoExpected);
            var result = await _productsController.All();

            // Assert
            Assert.IsType<ObjectResult>(result);

        }
        private List<Product> CreateProductList()
        {
            return new List<Product>
            {
                new Product
                {
                    Id = 1,
                    CompanyId = 1,
                    CategoryId = 1,
                    ProductName = "Product Test 1",
                    Stock = 10,
                    Price = 10
                },
                new Product
                {
                    Id = 2,
                    CompanyId = 1,
                    CategoryId = 1,
                    ProductName = "Product Test 2",
                    Stock = 10,
                    Price = 10
                }
            };
        }
        private List<ProductDto> MapModelToProductResultListDto(List<Product> products)
        {
            var listProduct = new List<ProductDto>();
            foreach(var item in products)
            {
                var product = new ProductDto
                {
                    Id = item.Id,
                    CompanyId = item.CompanyId,
                    CategoryId = item.CategoryId,
                    ProductName = item.ProductName,
                    Stock = item.Stock,
                    Price = item.Price
                };
                listProduct.Add(product);
            }
            return listProduct;
        }
    }
}
