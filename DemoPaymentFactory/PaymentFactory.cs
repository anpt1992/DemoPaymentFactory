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
            "Vietcombank" => GetService<VcbPaymentService>(),
            "Tienphongbank" => GetService<TpbPaymentService>(),
            _ => throw new InvalidOperationException($"Invalid {paymentName} payment service!")
        };

    private IPaymentService GetService<T>() => (IPaymentService) _serviceProvider.GetService(typeof(T));
}
