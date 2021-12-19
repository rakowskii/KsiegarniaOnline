using AutoMapper;
using OnlineBookstore.ApplicationServices.API.Domain.ReviewRequests;
using OnlineBookstore.ApplicationServices.API.Domain.ReviewResponses;
using OnlineBookstore.DataAccess;
using OnlineBookstore.DataAccess.CQRS.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineBookstore.ApplicationServices.API.Handlers
{
    public class GetReviewByProductTitleAndCoverHandler : IRequestHandler<GetReviewByProductTitleAndCoverRequest, GetReviewByProductTitleAndCoverResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetReviewByProductTitleAndCoverHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetReviewByProductTitleAndCoverResponse> Handle(GetReviewByProductTitleAndCoverRequest request, CancellationToken cancellationToken)
        {
            var query = new GetReviewByProductTitleAndCoverQuery
            {
                Title = request.Title,
                Cover = request.Cover
                
            };
            var reviews = await queryExecutor.Execute(query);
            var mappedReviews = mapper.Map<List<Domain.Models.Review>>(reviews);
            var response = new GetReviewByProductTitleAndCoverResponse
            {
                Data = mappedReviews
            };
            return response;
        }
    }
}
