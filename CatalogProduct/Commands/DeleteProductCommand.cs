using CatalogProduct.Models;

namespace CatalogProduct.Commands
{
    public class DeleteProductCommand
    {
        public Product Product { get; }

        public DeleteProductCommand(Product product)
        {
            Product = product;
        }
    }
}
