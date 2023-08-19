using DemoPaymentFactory.Model;

namespace DemoPaymentFactory.Services;

public class TcbPaymentService : IPaymentService
{
    public (bool result, string message) SubmitOrder(Order order) =>
        order.Data == string.Empty ? (false, "Cannot submit an empty order to TCB.") : (true, "Successfully submitted to TCB.");
}
