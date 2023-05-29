using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("api/checkout")]
    public class CheckoutController : ControllerBase
    {
        private readonly CheckoutService checkoutService;



        public CheckoutController()
        {
            checkoutService = new CheckoutService();
        }



        [HttpGet]
        public IActionResult CalculateTotalPrice(string skus)
        {
            decimal totalPrice = checkoutService.CalculateTotalPrice(skus);
            return Ok(totalPrice);
        }
    }
}
