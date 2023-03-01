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

        public ProductsApiControllerTest()
        {
            _productServiceMock = new Mock<IProductService>();
            _mapperMock = new Mock<IMapper>();
            _productsController = new ProductsController(_mapperMock.Object, _productServiceMock.Object);
        }

        [Fact] // OK!
        public async void All_ReturnsOkResult_WhenProductExists()
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

        [Fact] // OK!
        public async void GetById_ReturnsOkResult_WhenProductExists()
        {
            var product = CreateProduct();
            var dtoExpected = MapModelToProductResultDto(product);

            _productServiceMock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(product);
            _mapperMock.Setup(y => y.Map<ProductDto>(product)).Returns(dtoExpected);
            var result = await _productsController.GetById(1);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact] // OK!
        public async void GetById_ReturnsNotFoundResult_WhenProductDoesNotExist()
        {

            // Arrange
            _productServiceMock.Setup(x => x.GetByIdAsync(20)).ReturnsAsync((Product)null!);

            // Act
            var result = await _productsController.GetById(20);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact] // OK!
        public async void Save_ReturnsOkResult_WhenModelStateValid()
        {
            var product = CreateProduct();
            var dtoExpected = MapModelToProductResultDto(product);

            _productServiceMock.Setup(x => x.AddAsync(It.IsAny<Product>())).ReturnsAsync(product);

            var result = await _productsController.Save(dtoExpected);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact] // OK!
        public async void Update_ReturnsOkResult_WithMatchingIdAndProductDto()
        {
            // Arrange
            var product = CreateProduct();
            product.ProductName = "Test_Product_Name";
            var dtoExpected = MapModelToProductResultDto(product);

            // Act
            _productServiceMock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(product);
            _mapperMock.Setup(y => y.Map<Product>(dtoExpected)).Returns(product);
            var result = await _productsController.Update(dtoExpected);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact] // OK!
        public async void Update_ReturnsNotFound_WhenProductNotExists()
        {
            _productServiceMock.Setup(x => x.UpdateAsync(It.IsAny<Product>())).Throws(new Exception("Product is not found"));

            var result = await _productsController.GetById(20);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact] // OK!
        public async void Remove_ReturnsOkResult_WhenProductRemoved()
        {
            // Arrange
            var product = CreateProduct();
            var dtoExpected = MapModelToProductResultDto(product);

            // Act
            _productServiceMock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(product);
            _mapperMock.Setup(y => y.Map<Product>(dtoExpected)).Returns(product);
            var result = await _productsController.Remove(1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }


        public IEnumerable<Product> CreateProductList()
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
        public IEnumerable<ProductDto> MapModelToProductResultListDto(List<Product> products)
        {
            var listProduct = new List<ProductDto>();
            foreach (var item in products)
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
        public Product CreateProduct()
        {
            return new Product
            {
                Id = 1,
                CompanyId = 1,
                CategoryId = 1,
                ProductName = "Product Tester 2",
                Price = 20,
                Stock = 20,
            };
        }
        public ProductDto MapModelToProductResultDto(Product product)
        {
            var productDto = new ProductDto
            {
                Id = product.Id,
                CategoryId = product.CategoryId,
                CompanyId = product.CompanyId,
                ProductName = product.ProductName,
                Stock = product.Stock,
                Price = product.Price
            };
            return productDto;
        }
    }
}
