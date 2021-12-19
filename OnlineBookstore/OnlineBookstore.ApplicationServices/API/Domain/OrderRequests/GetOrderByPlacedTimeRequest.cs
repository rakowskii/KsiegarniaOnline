using OnlineBookstore.ApplicationServices.API.Domain.OrderResponses;
using MediatR;
using System;

namespace OnlineBookstore.ApplicationServices.API.Domain.OrderRequests
{
    public class GetOrderByPlacedTimeRequest : IRequest<GetOrderByPlacedTimeResponse>
    {
       public DateTime From { get; set; }
       public DateTime To { get; set; }

    }
}
