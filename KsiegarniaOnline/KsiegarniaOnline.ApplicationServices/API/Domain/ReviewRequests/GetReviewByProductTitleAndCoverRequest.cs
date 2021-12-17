using KsiegarniaOnline.ApplicationServices.API.Domain.ReviewResponses;
using KsiegarniaOnline.DataAccess.Entities;
using MediatR;

namespace KsiegarniaOnline.ApplicationServices.API.Domain.ReviewRequests
{
    public class GetReviewByProductTitleAndCoverRequest : IRequest<GetReviewByProductTitleAndCoverResponse>
    {
        public string Title { get; set; }
        public Product.Covers Cover { get; set; }
    }
}
