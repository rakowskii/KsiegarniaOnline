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
    public class GetReviewByProductTitleHandler : IRequestHandler<GetReviewByProductTitleRequest, GetReviewByProductTitleResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetReviewByProductTitleHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetReviewByProductTitleResponse> Handle(GetReviewByProductTitleRequest request, CancellationToken cancellationToken)
        {
            var query = new GetReviewByProductTitleQuery
            {
                Title = request.Title
            };
            var reviews = await queryExecutor.Execute(query);
            var mappedReviews = mapper.Map<List<Domain.Models.Review>>(reviews);
            var response = new GetReviewByProductTitleResponse
            {
                Data = mappedReviews
            };
            return response;
        }
    }
}
