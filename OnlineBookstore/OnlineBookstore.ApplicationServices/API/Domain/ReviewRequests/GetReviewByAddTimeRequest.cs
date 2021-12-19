using OnlineBookstore.ApplicationServices.API.Domain.ReviewResponses;
using MediatR;
using System;

namespace OnlineBookstore.ApplicationServices.API.Domain.ReviewRequests
{
    public class GetReviewByAddTimeRequest : IRequest<GetReviewByAddTimeResponse>
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }

    }
}
