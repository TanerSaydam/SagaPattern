namespace SagaPattern.Shared;
public sealed class PaymentResult
{
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public bool IsDone { get; set; }
}
