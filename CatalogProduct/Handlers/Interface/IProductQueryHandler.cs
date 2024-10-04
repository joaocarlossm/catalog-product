using System.Collections.Generic;
using System.Threading.Tasks;
using CatalogProduct.Models;
using CatalogProduct.Queries;

namespace CatalogProduct.Handlers
{
    public interface IProductQueryHandler
    {
        Task<IEnumerable<Product>> Handle(GetProductQuery query);
        Task<Product?> Handle(GetProductByIdQuery query);
    }
}
