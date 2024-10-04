using CatalogProduct.Models;

namespace CatalogProduct.Commands
{
    public class UpdateProductCommand
    {
        public Product Product { get; }

        public UpdateProductCommand(Product product)
        {
            Product = product;
        }
    }
}
