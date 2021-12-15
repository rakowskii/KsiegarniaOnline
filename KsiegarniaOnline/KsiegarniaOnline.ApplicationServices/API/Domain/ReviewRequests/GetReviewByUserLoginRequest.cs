﻿using KsiegarniaOnline.ApplicationServices.API.Domain.ReviewResponses;
using MediatR;

namespace KsiegarniaOnline.ApplicationServices.API.Domain.ReviewRequests
{
    public class GetReviewByUserLoginRequest : IRequest<GetReviewByUserLoginResponse>
    {
        public string Login { get; set; }
    }
}