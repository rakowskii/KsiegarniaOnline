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
