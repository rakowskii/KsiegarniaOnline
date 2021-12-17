using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using KsiegarniaOnline.ApplicationServices.API.Domain.OrderDetailsRequests;

namespace KsiegarniaOnline.Controllers
{
    [ApiController]
    [Route("")]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrderDetailsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("GetByOrderId/{orderId}")]
        public async Task<IActionResult> GetOrderDetailsByOrderId([FromRoute] int orderId)
        {
            var request = new GetOrderDetailsByOrderIdRequest
            {
                OrderId = orderId
            };
            var response = await mediator.Send(request);
            return Ok(response);

        }




    }
}
