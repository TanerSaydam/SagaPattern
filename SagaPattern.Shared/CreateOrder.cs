namespace SagaPattern.Shared;

public sealed class CreateOrder
{
    public Guid OrderId { get; set; } = Guid.NewGuid();
    public Guid ProductId { get; set; } = Guid.NewGuid();
    public string CardNumber { get; set; } = "11111";
}
