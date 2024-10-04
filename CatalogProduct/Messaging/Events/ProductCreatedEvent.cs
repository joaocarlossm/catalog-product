using CatalogProduct.Models;

namespace CatalogProduct.Messaging.Events
{
    public class ProductCreatedEvent
    {
        public Product Product { get; }

        public ProductCreatedEvent(Product product)
        {
            Product = product;
        }
    }
}
