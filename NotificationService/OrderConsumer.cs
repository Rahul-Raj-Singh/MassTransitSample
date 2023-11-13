using Contracts;
using MassTransit;
using Newtonsoft.Json;

namespace NotificationService;

public class OrderConsumer : IConsumer<Order>
{
    private readonly ILogger<OrderConsumer> _logger;

    public OrderConsumer(ILogger<OrderConsumer> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<Order> context)
    {
        _logger.LogInformation("Received order from RabbitMQ:\n{msg}", JsonConvert.SerializeObject(context.Message));
        
        await Task.CompletedTask;
    }
}