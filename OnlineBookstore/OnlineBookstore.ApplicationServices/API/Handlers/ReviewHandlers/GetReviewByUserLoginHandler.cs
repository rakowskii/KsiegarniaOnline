using AutoMapper;
using OnlineBookstore.ApplicationServices.API.Domain.ReviewRequests;
using OnlineBookstore.ApplicationServices.API.Domain.ReviewResponses;
using OnlineBookstore.DataAccess;
using OnlineBookstore.DataAccess.CQRS.Queries;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OnlineBookstore.ApplicationServices.API.Domain;
using OnlineBookstore.ApplicationServices.API.ErrorHandling;

namespace OnlineBookstore.ApplicationServices.API.Handlers
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
            if (reviews == null)
            {
                return new GetReviewByUserLoginResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedReviews = mapper.Map<List<Domain.Models.Review>>(reviews);
            var response = new GetReviewByUserLoginResponse
            {
                Data = mappedReviews
            };
            return response;
        }
    }
}