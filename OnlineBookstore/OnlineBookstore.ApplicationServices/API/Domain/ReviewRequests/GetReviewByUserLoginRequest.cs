using OnlineBookstore.ApplicationServices.API.Domain.ReviewResponses;
using MediatR;

namespace OnlineBookstore.ApplicationServices.API.Domain.ReviewRequests
{
    public class GetReviewByUserLoginRequest : IRequest<GetReviewByUserLoginResponse>
    {
        public string Username { get; set; }
    }
}
