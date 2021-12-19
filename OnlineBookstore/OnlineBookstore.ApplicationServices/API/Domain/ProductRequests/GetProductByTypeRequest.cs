using OnlineBookstore.ApplicationServices.API.Domain.ProductResponses;
using OnlineBookstore.DataAccess.Entities;
using MediatR;

namespace OnlineBookstore.ApplicationServices.API.Domain.ProductRequests
{
    public class GetProductByTypeRequest : IRequest<GetProductByTypeResponse>
    {
        public Product.Types Type { get; set; }
    }
}
