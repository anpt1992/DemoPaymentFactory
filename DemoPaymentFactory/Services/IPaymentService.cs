using DemoPaymentFactory.Model;

namespace DemoPaymentFactory.Services
{
    public interface IPaymentService
    {
        public (bool result, string message) SubmitOrder(Order order);
    }
}