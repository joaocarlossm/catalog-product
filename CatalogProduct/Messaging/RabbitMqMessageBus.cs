using CatalogProduct.Messaging;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class RabbitMqMessageBus : IMessageBus
{
    private readonly IConnection _connection;

    public RabbitMqMessageBus()
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        _connection = factory.CreateConnection();
    }

    public async Task PublishAsync<T>(T message)
    {
        using var channel = _connection.CreateModel();
        channel.QueueDeclare(queue: "produtos",
                             durable: false,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);

        var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
        channel.BasicPublish(exchange: "",
                             routingKey: "produtos",
                             basicProperties: null,
                             body: body);
    }
}
