using CatalogProduct.Commands;
using CatalogProduct.Handlers;
using CatalogProduct.Messaging.Events;
using CatalogProduct.Messaging;
using CatalogProduct.Repositories.Interface;

public class ProductCommandHandler : IProductCommandHandler
{
    private readonly IProductRepository _repository;
    private readonly IMessageBus _messageBus;

    public ProductCommandHandler()
    {
        // Construtor sem parâmetros
    }

    public ProductCommandHandler(IProductRepository repository, IMessageBus messageBus)
    {
        _repository = repository;
        _messageBus = messageBus;
    }

    public virtual async Task Handle(CreateProductCommand command)
    {
        await _repository.AddAsync(command.Product);
        await _messageBus.PublishAsync(new ProductCreatedEvent(command.Product));
    }

    public virtual async Task Handle(UpdateProductCommand command)
    {
        await _repository.UpdateAsync(command.Product);
    }

    public virtual async Task Handle(DeleteProductCommand command)
    {
        await _repository.DeleteAsync(command.Product.Id);
    }
}
