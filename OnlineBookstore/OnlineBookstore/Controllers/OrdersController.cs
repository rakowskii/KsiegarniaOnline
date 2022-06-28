using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.ApplicationServices.API.Domain.OrderRequests;
using OnlineBookstore.ApplicationServices.API.Domain.OrderResponses;
using System;
using System.Threading.Tasks;

namespace OnlineBookstore.Controllers
{
    [ApiController]
    [Route("")]
    public class OrdersController : ApiControllerBase
    {
        
        public OrdersController(IMediator mediator) : base(mediator)
        {
        }
           

        [HttpGet]
        [Route("GetAllOrders")]
        public Task<IActionResult> GetAllOrders([FromQuery] GetAllOrdersRequest request)
        {
            return this.HandleRequest<GetAllOrdersRequest, GetAllOrdersResponse>(request);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public Task<IActionResult> GetOrderById([FromRoute] int id)
        {
            var request = new GetOrderByIdRequest
            {
                OrderId = id
            };
            return this.HandleRequest<GetOrderByIdRequest, GetOrderByIdResponse>(request);
        }

        [HttpGet]
        [Route("GetByUserLogin/{login}")]
        public Task<IActionResult> GetOrderByUserLogin([FromRoute] string login)
        {
            var request = new GetOrderByUserLoginRequest
            {
                UserLogin = login
            };
            return this.HandleRequest<GetOrderByUserLoginRequest, GetOrderByUserLoginResponse>(request);
        }

        [HttpGet]
        [Route("GetByPlacedTime/{From}/{To}")]
        public Task<IActionResult> GetOrderByPlacedTime([FromRoute] DateTime from, DateTime to)
        {
            var request = new GetOrderByPlacedTimeRequest
            {
                From = from,
                To = to
            };
            return this.HandleRequest<GetOrderByPlacedTimeRequest, GetOrderByPlacedTimeResponse>(request);
        }

        [HttpGet]
        [Route("GetByTotalPrice/{from}/{to}")]
        public Task<IActionResult> GetOrderByTotalPrice([FromRoute] decimal from, decimal to)
        {
            var request = new GetOrderByTotalPriceRequest
            {
                From = from,
                To = to
            };
            return this.HandleRequest<GetOrderByTotalPriceRequest, GetOrderByTotalPriceResponse>(request);
        }
    }
}