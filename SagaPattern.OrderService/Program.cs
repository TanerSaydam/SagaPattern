using MassTransit;
using SagaPattern.OrderService;
using SagaPattern.Shared;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<OrderConsumer>();
    x.UsingRabbitMq((context, cfr) =>
    {
        cfr.Host("localhost", "/", h => { });
        cfr.ReceiveEndpoint("order-payment-result", e =>
        {
            e.ConfigureConsumer<OrderConsumer>(context);
        });
    });
});

var app = builder.Build();

app.MapDefaultEndpoints();

app.MapGet("/create-order", async (IPublishEndpoint publishEndpoint) =>
{
    //dbye gönder sipariþi oluþtur

    //payment için kuyruða gönder
    await publishEndpoint.Publish(new CreateOrder());

    //iþlemi tamamlayýp son kullanýcýya bildirim ver
    return Results.Created();
});

app.Run();