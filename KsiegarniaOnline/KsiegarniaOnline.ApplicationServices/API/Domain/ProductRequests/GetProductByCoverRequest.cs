using KsiegarniaOnline.ApplicationServices.API.Domain.ProductResponses;
using KsiegarniaOnline.DataAccess.Entities;
using MediatR;

namespace KsiegarniaOnline.ApplicationServices.API.Domain.ProductRequests
{
    public class GetProductByCoverRequest : IRequest<GetProductByCoverResponse>
    {
        public Product.Covers Cover { get; set; }
    }
}
