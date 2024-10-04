namespace CatalogProduct.Messaging
{
    public interface IMessageBus
    {
        Task PublishAsync<T>(T message);
    }

}
