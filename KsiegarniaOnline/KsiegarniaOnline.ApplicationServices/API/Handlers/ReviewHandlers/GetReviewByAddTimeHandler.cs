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
    public class GetReviewByAddTimeHandler : IRequestHandler<GetReviewByAddTimeRequest, GetReviewByAddTimeResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetReviewByAddTimeHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetReviewByAddTimeResponse> Handle(GetReviewByAddTimeRequest request, CancellationToken cancellationToken)
        {
            var query = new GetReviewByAddTimeQuery
            { 
                From = request.From,
                To = request.To
            };
            var reviews = await queryExecutor.Execute(query);
            var mappedReviews = mapper.Map<List<Domain.Models.Review>>(reviews);
            var response = new GetReviewByAddTimeResponse
            {
                Data = mappedReviews
            };
            return  response;
        }
    }
}
