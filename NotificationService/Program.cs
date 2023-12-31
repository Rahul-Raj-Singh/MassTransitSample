using MassTransit;
using NotificationService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(config => {

    config.AddConsumer<OrderConsumer>();

    config.UsingRabbitMq((ctx, cfg) => {
        cfg.Host("amqp://guest:guest@localhost:5672");

        cfg.ReceiveEndpoint("order-placed", c => {
            c.ConfigureConsumer<OrderConsumer>(ctx);
        });
    });

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
