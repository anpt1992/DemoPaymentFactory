using DemoPaymentFactory.Services;

namespace DemoPaymentFactory;

public interface IPaymentFactory
{
    IPaymentService GetPaymentService(string paymentName);
}

public class PaymentFactory : IPaymentFactory
{
    private readonly IServiceProvider _serviceProvider;
    public PaymentFactory(IServiceProvider serviceProvider) =>  _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

    public IPaymentService GetPaymentService(string paymentName) =>
        paymentName switch
        {
            "Vietcombank" => GetPayment<VcbPaymentService>(),
            "Tienphongbank" => GetPayment<TpbPaymentService>(),
            _ => throw new ArgumentException($"Unsupported payment method: {paymentName}!")
        };

    private IPaymentService GetPayment<T>() => (IPaymentService) _serviceProvider.GetService(typeof(T));
}
