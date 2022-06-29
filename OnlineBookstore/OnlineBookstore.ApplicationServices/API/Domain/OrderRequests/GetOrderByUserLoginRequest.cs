using OnlineBookstore.ApplicationServices.API.Domain.OrderResponses;
using MediatR;
using System;

namespace OnlineBookstore.ApplicationServices.API.Domain.OrderRequests
{
    public class GetOrderByUserLoginRequest : IRequest<GetOrderByUserLoginResponse>
    { 
        public string Username { get; set; }
    }
}

    
