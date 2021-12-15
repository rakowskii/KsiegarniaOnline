using KsiegarniaOnline.ApplicationServices.API.Domain.ReviewResponses;
using MediatR;

namespace KsiegarniaOnline.ApplicationServices.API.Domain.ReviewRequests
{
    public class GetReviewByProductTitleRequest : IRequest<GetReviewByProductTitleResponse>
    {
        public string Title { get; set; }
    }
}
