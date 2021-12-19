using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using OnlineBookstore.ApplicationServices.API.Domain.OrderRequests;

namespace OnlineBookstore.Controllers
{
    [ApiController]
    [Route("")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrdersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("GetAllOrders")]
        public async Task<IActionResult> GetAllOrders([FromQuery] GetAllOrdersRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetOrderById([FromRoute] int id)
        {
            var request = new GetOrderByIdRequest
            {
                OrderId = id
            };
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetByUserLogin/{login}")]
        public async Task<IActionResult> GetOrderByUserLogin([FromRoute] string login)
        {
            var request = new GetOrderByUserLoginRequest
            {
                UserLogin = login
            };
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetByPlacedTime/{From}/{To}")]
        public async Task<IActionResult> GetOrderByPlacedTime([FromRoute] DateTime from, DateTime to)
        {
            var request = new GetOrderByPlacedTimeRequest
            {
                From = from,
                To = to
            };
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetByTotalPrice/{from}/{to}")]
        public async Task<IActionResult> GetOrderByTotalPrice([FromRoute] decimal from, decimal to)
        {
            var request = new GetOrderByTotalPriceRequest
            {
                From = from,
                To = to
            };
            var response = await mediator.Send(request);
            return Ok(response);
        }

        


    }
}
       

