using OnlineBookstore.ApplicationServices.API.Domain.ProductResponses;
using OnlineBookstore.DataAccess.Entities;
using MediatR;

namespace OnlineBookstore.ApplicationServices.API.Domain.ProductRequests
{
    public class GetProductByCategoryRequest : IRequest<GetProductByCategoryResponse>
    {
        public Product.Categories Category { get; set; }
    }
}
