using KsiegarniaOnline.ApplicationServices.API.Domain.ProductResponses;
using MediatR;

namespace KsiegarniaOnline.ApplicationServices.API.Domain.ProductRequests
{
    public class GetProductByPublisherRequest : IRequest<GetProductByPublisherResponse>
    {
        public string Publisher { get; set; }
    }
}
