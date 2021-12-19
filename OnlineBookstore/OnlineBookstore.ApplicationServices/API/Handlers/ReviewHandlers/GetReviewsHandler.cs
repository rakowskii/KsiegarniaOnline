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
    public class GetReviewsHandler : IRequestHandler<GetReviewsRequest, GetReviewsResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;
        
        public GetReviewsHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetReviewsResponse> Handle(GetReviewsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetAllReviewsQuery();
            var reviews = await queryExecutor.Execute(query);
            var mappedReviews = mapper.Map<List<Domain.Models.Review>>(reviews); 
            var response = new GetReviewsResponse
            {
                Data = mappedReviews
            };
            return response;
        }
    }
}


    


