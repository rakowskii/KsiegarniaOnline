using OnlineBookstore.ApplicationServices.API.Domain.ProductResponses;
using MediatR;

namespace OnlineBookstore.ApplicationServices.API.Domain.ProductRequests
{
    public class GetProductByPublisherRequest : IRequest<GetProductByPublisherResponse>
    {
        public string Publisher { get; set; }
    }
}
