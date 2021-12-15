using KsiegarniaOnline.ApplicationServices.API.Domain.ProductResponses;
using MediatR;

namespace KsiegarniaOnline.ApplicationServices.API.Domain.ProductRequests
{
    public class GetProductByAuthorRequest : IRequest<GetProductByAuthorResponse>
    {
        public string ProductsAuthor { get; set; }
    }
}
