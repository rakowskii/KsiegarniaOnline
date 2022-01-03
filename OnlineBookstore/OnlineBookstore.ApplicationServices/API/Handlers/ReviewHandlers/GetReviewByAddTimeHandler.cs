using AutoMapper;
using OnlineBookstore.ApplicationServices.API.Domain.ReviewRequests;
using OnlineBookstore.ApplicationServices.API.Domain.ReviewResponses;
using OnlineBookstore.DataAccess;
using OnlineBookstore.DataAccess.CQRS.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OnlineBookstore.ApplicationServices.API.Domain.ProductResponses;
using OnlineBookstore.ApplicationServices.API.Domain;
using OnlineBookstore.ApplicationServices.API.ErrorHandling;

namespace OnlineBookstore.ApplicationServices.API.Handlers
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
            if (reviews == null)
            {
                return new GetReviewByAddTimeResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedReviews = mapper.Map<List<Domain.Models.Review>>(reviews);
            var response = new GetReviewByAddTimeResponse
            {
                Data = mappedReviews
            };
            return  response;
        }
    }
}
