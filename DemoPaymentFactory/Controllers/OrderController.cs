using DemoPaymentFactory.Model;
using Microsoft.AspNetCore.Mvc;

namespace DemoPaymentFactory.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{   
    private readonly ILogger<OrderController> _logger;
    private readonly IPaymentFactory _paymentFactory;

    public OrderController(IPaymentFactory paymentFactory, ILogger<OrderController> logger)
    {
        _paymentFactory = paymentFactory;
        _logger = logger;
    }

    [HttpPost(Name = "SubmitOrder")]
    public IActionResult SubmitOrder(Order order)
    {
       var paymentService = _paymentFactory.GetPaymentService(order.PaymentName);
        var (result,message) =paymentService.SubmitOrder(order);
        if(result)
        {
            _logger.LogInformation(message);
            return Ok(message);
        }
        _logger.LogError(message);
        return BadRequest(message);
        
    }
}