using OnlineBookstore.ApplicationServices.API.Domain.ReviewResponses;
using OnlineBookstore.DataAccess.Entities;
using MediatR;

namespace OnlineBookstore.ApplicationServices.API.Domain.ReviewRequests
{
    public class GetReviewByProductTitleAndCoverRequest : IRequest<GetReviewByProductTitleAndCoverResponse>
    {
        public string Title { get; set; }
        public Product.Covers Cover { get; set; }
    }
}
