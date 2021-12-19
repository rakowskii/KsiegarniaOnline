using OnlineBookstore.ApplicationServices.API.Domain.ProductResponses;
using MediatR;

namespace OnlineBookstore.ApplicationServices.API.Domain.ProductRequests
{
    public class GetProductByAuthorRequest : IRequest<GetProductByAuthorResponse>
    {
        public string ProductsAuthor { get; set; }
    }
}
