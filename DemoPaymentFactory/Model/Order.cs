namespace DemoPaymentFactory.Model;

public record Order
{
    public string PaymentName { get; init; } = string.Empty;
    public string Data { get; init; } = string.Empty;
}
