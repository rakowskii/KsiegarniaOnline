using OnlineBookstore.ApplicationServices.API.Domain.OrderResponses;
using MediatR;

namespace OnlineBookstore.ApplicationServices.API.Domain.OrderRequests
{
    public class GetOrderByIdRequest : IRequest<GetOrderByIdResponse>
    {
        public int OrderId { get; set; }
    }
}
