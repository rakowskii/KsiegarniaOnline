using AutoMapper;
using OnlineBookstore.ApplicationServices.API.Domain.UserRequests;
using OnlineBookstore.ApplicationServices.API.Domain.UserResponses;
using OnlineBookstore.DataAccess;
using OnlineBookstore.DataAccess.CQRS.Queries.Users;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using OnlineBookstore.ApplicationServices.API.Domain;
using OnlineBookstore.ApplicationServices.API.ErrorHandling;

namespace OnlineBookstore.ApplicationServices.API.Handlers.UserHandlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdRequest, GetUserByIdResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetUserByIdHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }
        public async Task<GetUserByIdResponse> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUserByIdQuery
            {
                Id = request.UserId
            };
            var user = await queryExecutor.Execute(query);
            if (user == null)
            {
                return new GetUserByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedUser = mapper.Map<Domain.Models.User>(user);
            return new GetUserByIdResponse
            {
                Data = mappedUser
            };
        }
    }
}