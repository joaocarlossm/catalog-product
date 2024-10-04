using CatalogProduct.Models;

namespace CatalogProduct.Commands
{
    public class CreateProductCommand
    {
        public Product Product { get; }

        public CreateProductCommand(Product product)
        {
            Product = product;
        }
    }
}