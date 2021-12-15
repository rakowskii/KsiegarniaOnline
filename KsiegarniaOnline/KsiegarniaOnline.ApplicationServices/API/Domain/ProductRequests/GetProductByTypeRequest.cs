using KsiegarniaOnline.ApplicationServices.API.Domain.ProductResponses;
using KsiegarniaOnline.DataAccess.Entities;
using MediatR;

namespace KsiegarniaOnline.ApplicationServices.API.Domain.ProductRequests
{
    public class GetProductByTypeRequest : IRequest<GetProductByTypeResponse>
    {
        public Product.Types Type { get; set; }
    }
}
