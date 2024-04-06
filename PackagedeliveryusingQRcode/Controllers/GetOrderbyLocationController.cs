using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PackagedeliveryusingQRcode.Models;

namespace PackagedeliveryusingQRcode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetOrderbyLocationController : ControllerBase
    {
        private PackageDeliveryusingQrcodeContext context;

        public GetOrderbyLocationController(PackageDeliveryusingQrcodeContext context)
        {
            this.context = context;
        }
        [HttpGet("{id}")]

        public async Task<ActionResult<IEnumerable<Order>>> GetOrderbyLocation(string id)
        {

            var Orders = await (from Customer in context.Customers join Order in context.Orders on Customer.CustomerId equals Order.CustomerId where Customer.CustomerLocation == id select Order).ToListAsync();

            return Orders;
             


;        }
    }

}
