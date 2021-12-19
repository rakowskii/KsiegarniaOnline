using OnlineBookstore.ApplicationServices.API.Domain.ProductResponses;
using OnlineBookstore.DataAccess.Entities;
using MediatR;

namespace OnlineBookstore.ApplicationServices.API.Domain.ProductRequests
{
    public class GetProductByCoverRequest : IRequest<GetProductByCoverResponse>
    {
        public Product.Covers Cover { get; set; }
    }
}
