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
    //dbye g�nder sipari�i olu�tur

    //payment i�in kuyru�a g�nder
    await publishEndpoint.Publish(new CreateOrder());

    //i�lemi tamamlay�p son kullan�c�ya bildirim ver
    return Results.Created();
});

app.Run();