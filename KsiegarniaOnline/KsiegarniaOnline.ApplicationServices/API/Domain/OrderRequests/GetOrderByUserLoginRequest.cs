using KsiegarniaOnline.ApplicationServices.API.Domain.OrderResponses;
using MediatR;
using System;

namespace KsiegarniaOnline.ApplicationServices.API.Domain.OrderRequests
{
    public class GetOrderByUserLoginRequest : IRequest<GetOrderByUserLoginResponse>
    { 
        public string UserLogin { get; set; }
    }
}

    
