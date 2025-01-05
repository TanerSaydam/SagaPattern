using MassTransit;
using SagaPattern.Shared;

namespace SagaPattern.OrderService;

public sealed class OrderConsumer : IConsumer<PaymentResult>
{
    public Task Consume(ConsumeContext<PaymentResult> context)
    {
        // sipariş durumunu işlem başarılı ya da başarısıza göre değiştirebilir

        // eğer işlem başarılı ise product kuyruğuna haber verip stoktan düşülmesini sağlayabilir

        return Task.CompletedTask;
    }
}
