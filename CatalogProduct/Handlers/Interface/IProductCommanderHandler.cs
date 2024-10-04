using CatalogProduct.Commands;

public interface IProductCommandHandler
{
    Task Handle(CreateProductCommand command);
    Task Handle(UpdateProductCommand command);
    Task Handle(DeleteProductCommand command);
}
