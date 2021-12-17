using KsiegarniaOnline.ApplicationServices.API.Domain.OrderResponses;
using MediatR;

namespace KsiegarniaOnline.ApplicationServices.API.Domain.OrderRequests
{
    public class GetOrderByIdRequest : IRequest<GetOrderByIdResponse>
    {
        public int OrderId { get; set; }
    }
}
