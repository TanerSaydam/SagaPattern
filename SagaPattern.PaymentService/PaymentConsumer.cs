using MassTransit;
using SagaPattern.Shared;

namespace SagaPattern.PaymentService;

public sealed class PaymentConsumer(IPublishEndpoint publishEndpoint) : IConsumer<CreateOrder>
{
    public async Task Consume(ConsumeContext<CreateOrder> context)
    {
        //ödeme başarılı ya da başarısız durumuna göre işlem yapacağım

        var result = new PaymentResult()
        {
            OrderId = context.Message.OrderId,
            ProductId = context.Message.ProductId,
            IsDone = true
        };
        await publishEndpoint.Publish(result);
    }
}
