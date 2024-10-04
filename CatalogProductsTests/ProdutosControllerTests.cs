using CatalogProduct.Commands;
using CatalogProduct.Controllers;
using CatalogProduct.Handlers;
using CatalogProduct.Models;
using CatalogProduct.Queries;
using Microsoft.AspNetCore.Mvc;
using Moq;
using CatalogProduct.Repositories.Interface;

namespace MyApp.Tests
{
    public class ProdutosControllerTests
    {
        private readonly ProductsController _controller;
        private readonly Mock<IProductCommandHandler> _mockCommandHandler;
        private readonly Mock<IProductQueryHandler> _mockQueryHandler;
        private readonly Mock<IProductRepository> _repositoryMock;

        public ProdutosControllerTests()
        {
            _repositoryMock = new Mock<IProductRepository>();
            var messageBusMock = new Mock<CatalogProduct.Messaging.IMessageBus>();
            _mockCommandHandler = new Mock<IProductCommandHandler>();
            _mockQueryHandler = new Mock<IProductQueryHandler>();
            _controller = new ProductsController(_mockCommandHandler.Object, _mockQueryHandler.Object);
        }

        [Fact]
        public async Task GetProducts_ReturnsOkResult_WithListOfProducts()
        {
            // Arrange
            var products = new List<Product> { new Product { Id = 1, Nome = "Product1", Preco = 10, Descricao = "Descricao1" } };
            _mockQueryHandler.Setup(handler => handler.Handle(It.IsAny<GetProductQuery>())).ReturnsAsync(products);

            // Act
            var result = await _controller.GetProducts();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnProducts = Assert.IsType<List<Product>>(okResult.Value);
            Assert.Single(returnProducts);
        }

        [Fact]
        public async Task GetProduct_ReturnsNotFound_WhenProductDoesNotExist()
        {
            // Arrange
            _mockQueryHandler.Setup(handler => handler.Handle(It.IsAny<GetProductByIdQuery>())).ReturnsAsync((Product?)null);

            // Act
            var result = await _controller.GetProduct(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task CreateProduct_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var product = new Product { Id = 1, Nome = "Product1", Preco = 10, Descricao = "Descricao1" };
            _mockCommandHandler.Setup(handler => handler.Handle(It.IsAny<CreateProductCommand>())).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.CreateProduct(product);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("GetProduct", createdAtActionResult.ActionName);
        }

        [Fact]
        public async Task UpdateProduct_ReturnsNoContentResult()
        {
            // Arrange
            var product = new Product { Id = 1, Nome = "Product1", Preco = 10, Descricao = "Descricao1" };
            _mockCommandHandler.Setup(handler => handler.Handle(It.IsAny<UpdateProductCommand>())).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.UpdateProduct(product);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }


        [Fact]
        public async Task DeleteProduct_ReturnsNoContentResult()
        {
            // Arrange
            var product = new Product { Id = 1, Nome = "Product1", Preco = 10, Descricao = "Descricao1" };
            _mockQueryHandler.Setup(handler => handler.Handle(It.IsAny<GetProductByIdQuery>())).ReturnsAsync(product);
            _mockCommandHandler.Setup(handler => handler.Handle(It.IsAny<DeleteProductCommand>())).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.DeleteProduct(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
