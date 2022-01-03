using AutoMapper;
using OnlineBookstore.ApplicationServices.API.Domain.UserRequests;
using OnlineBookstore.ApplicationServices.API.Domain.UserResponses;
using OnlineBookstore.DataAccess;
using OnlineBookstore.DataAccess.CQRS.Queries.Users;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OnlineBookstore.ApplicationServices.API.Domain.ReviewResponses;
using OnlineBookstore.ApplicationServices.API.Domain;
using OnlineBookstore.ApplicationServices.API.ErrorHandling;

namespace OnlineBookstore.ApplicationServices.API.Handlers.UserHandlers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersRequest, GetAllUsersResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetAllUsersHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }
        public async Task<GetAllUsersResponse> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
        {
            var query = new GetAllUsersQuery();
            var user = await queryExecutor.Execute(query);
            if (user == null)
            {
                return new GetAllUsersResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedUser = mapper.Map<List<Domain.Models.User>>(user);
            return new GetAllUsersResponse
            {
                Data = mappedUser
            };
        }
    }
}
            