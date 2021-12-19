using OnlineBookstore.ApplicationServices.API.Domain.OrderResponses;
using MediatR;

namespace OnlineBookstore.ApplicationServices.API.Domain.OrderRequests
{
    public class GetAllOrdersRequest : IRequest<GetAllOrdersResponse>
    {
    }
}
