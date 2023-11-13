using Contracts;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace OrderService.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly IPublishEndpoint _publishEndpoint;

    public OrderController(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    [HttpPost("/order")]
    public IActionResult Post([FromBody] Order order)
    {
        _publishEndpoint.Publish<Order>(order);
        
        return Ok("Published to RabbitMQ");
    }
}
