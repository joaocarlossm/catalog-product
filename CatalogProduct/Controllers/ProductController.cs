using Microsoft.AspNetCore.Mvc;
using CatalogProduct.Handlers;
using CatalogProduct.Models;
using CatalogProduct.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using CatalogProduct.Commands;

namespace CatalogProduct.Controllers
{
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    [Route("api/[controller]")]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductCommandHandler _commandHandler;
        private readonly IProductQueryHandler _queryHandler;

        public ProductsController(IProductCommandHandler commandHandler, IProductQueryHandler queryHandler)
        {
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var query = new GetProductQuery();
            var products = await _queryHandler.Handle(query);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var query = new GetProductByIdQuery(id);
            var product = await _queryHandler.Handle(query);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct(Product product)
        {
            var command = new CreateProductCommand(product);
            await _commandHandler.Handle(command);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProduct(Product product)
        {
            var command = new UpdateProductCommand(product);
            await _commandHandler.Handle(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await _queryHandler.Handle(new GetProductByIdQuery(id));
            if (product == null) return NotFound();

            var command = new DeleteProductCommand(product);
            await _commandHandler.Handle(command);
            return NoContent();
        }
    }
}
