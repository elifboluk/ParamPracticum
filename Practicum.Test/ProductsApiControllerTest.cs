using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Practicum.API.Controllers;
using Practicum.Core.DTOs;
using Practicum.Core.Entities;
using Practicum.Core.Services;
using System.ComponentModel.Design;
using System.Net;

namespace Practicum.Test
{
    public class ProductsApiControllerTest
    {        
        private readonly Mock<IProductService> _productServiceMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ProductsController _productsController;

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
            var dtoExpected = MapModelToProductResultListDto(products.ToList()); // Return Dto

            // Act
            _productServiceMock.Setup(x => x.GetAllAsync()).ReturnsAsync(products);
            _mapperMock.Setup(y => y.Map<IEnumerable<ProductDto>>(It.IsAny<List<Product>>())).Returns(dtoExpected);
            var result = await _productsController.All();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void GetById_ShouldReturnCreateActionResultSucces_WhenProductExist()
        {
            var product = CreateProduct();
            var dtoExpected = MapModelToProductResultDto(product);

            _productServiceMock.Setup(x => x.GetByIdAsync(2)).ReturnsAsync(product);
            _mapperMock.Setup(y => y.Map<ProductDto>(It.IsAny<Product>())).Returns(dtoExpected);
            var result = await _productsController.GetById(2);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void GetById_ShouldReturnNotFound_WhenProductNotExist()
        {
            _productServiceMock.Setup(x => x.GetByIdAsync(20)).ReturnsAsync((Product)null);
            var result = await _productsController.GetById(20);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void Save_ShouldBeReturnBadRequest_WhenModelStateInvalid()
        {
            var productDto = new ProductDto();
            _productsController.ModelState.AddModelError("ProductName", "The field name is required!");

            var result = await _productsController.Save(productDto);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void Save_StringListHelloWorld_ArgumentOutOfRangeException()
        {
            // Arrange
            var stringList = new List<string>();

            // Act
            Action actual = () =>
            {
                stringList.Add("Hello");
                stringList[5] = "Hello World";
            };

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(actual);
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
        private Product CreateProduct()
        {
            return new Product
            {
                Id = 5,
                CompanyId = 1,
                CategoryId = 1,
                ProductName = "Product Tester 2",
                Price = 20,
                Stock = 20,                
            };
        }
        private ProductDto MapModelToProductResultDto(Product product)
        {
            var productDto = new ProductDto
            {
                Id = product.Id,
                CategoryId= product.CategoryId,
                CompanyId= product.CompanyId,
                ProductName= product.ProductName,
                Stock= product.Stock,
                Price = product.Price
            };
            return productDto;
        }
    }
}
