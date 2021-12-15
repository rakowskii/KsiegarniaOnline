using AutoMapper;
using KsiegarniaOnline.ApplicationServices.API.Domain.ReviewRequests;
using KsiegarniaOnline.ApplicationServices.API.Domain.ReviewResponses;
using KsiegarniaOnline.DataAccess;
using KsiegarniaOnline.DataAccess.CQRS.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KsiegarniaOnline.ApplicationServices.API.Handlers
{
    public class GetReviewByUserLoginHandler : IRequestHandler<GetReviewByUserLoginRequest, GetReviewByUserLoginResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetReviewByUserLoginHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetReviewByUserLoginResponse> Handle(GetReviewByUserLoginRequest request, CancellationToken cancellationToken)
        {
            var query = new GetReviewByUserLoginQuery
            {
                Login = request.Login
            };
            var reviews = await queryExecutor.Execute(query);
            var mappedReviews = mapper.Map<List<Domain.Models.Review>>(reviews);
            var response = new GetReviewByUserLoginResponse
            {
                Data = mappedReviews
            };
            return response;
        }
    }
}