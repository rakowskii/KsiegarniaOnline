using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.ApplicationServices.API.Domain.OrderDetailsRequests;
using OnlineBookstore.ApplicationServices.API.Domain.OrderDetailsResponses;
using System.Threading.Tasks;

namespace OnlineBookstore.Controllers
{
    [ApiController]
    [Route("")]
    public class OrderDetailsController : ApiControllerBase
    {

        public OrderDetailsController(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet]
        [Route("GetByOrderId/{orderId}")]
        public Task<IActionResult> GetOrderDetailsByOrderId([FromRoute] int orderId)
        {
            var request = new GetOrderDetailsByOrderIdRequest
            {
                OrderId = orderId
            };
            return this.HandleRequest<GetOrderDetailsByOrderIdRequest, GetOrderDetailsByOrderIdResponse>(request);
        }
    }
}