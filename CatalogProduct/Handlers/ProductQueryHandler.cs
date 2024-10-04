using System.Collections.Generic;
using System.Threading.Tasks;
using CatalogProduct.Models;
using CatalogProduct.Queries;
using CatalogProduct.Repositories.Interface;

namespace CatalogProduct.Handlers
{
    public class ProductQueryHandler : IProductQueryHandler
    {
        private readonly IProductRepository _repository;

        public ProductQueryHandler()
        {
            // Construtor sem parâmetros
        }

        public ProductQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductQuery query)
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Product?> Handle(GetProductByIdQuery query)
        {
            return await _repository.GetByIdAsync(query.Id);
        }
    }
}
