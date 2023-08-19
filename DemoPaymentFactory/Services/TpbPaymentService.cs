using DemoPaymentFactory.Model;

namespace DemoPaymentFactory.Services;

public class TpbPaymentService : IPaymentService
{
    public (bool result, string message) SubmitOrder(Order order) =>
        order.Data == string.Empty ? (false, "Cannot submit an empty order to TPB.") : (true, "Successfully submitted to TPB.");
}
