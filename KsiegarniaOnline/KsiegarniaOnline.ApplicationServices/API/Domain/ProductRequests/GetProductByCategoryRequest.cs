using KsiegarniaOnline.ApplicationServices.API.Domain.ProductResponses;
using KsiegarniaOnline.DataAccess.Entities;
using MediatR;

namespace KsiegarniaOnline.ApplicationServices.API.Domain.ProductRequests
{
    public class GetProductByCategoryRequest : IRequest<GetProductByCategoryResponse>
    {
        public Product.Categories Category { get; set; }
    }
}
