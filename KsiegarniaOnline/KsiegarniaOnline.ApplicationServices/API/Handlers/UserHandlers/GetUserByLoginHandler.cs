using AutoMapper;
using KsiegarniaOnline.ApplicationServices.API.Domain.UserRequests;
using KsiegarniaOnline.ApplicationServices.API.Domain.UserResponses;
using KsiegarniaOnline.DataAccess;
using KsiegarniaOnline.DataAccess.CQRS.Queries.Users;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KsiegarniaOnline.ApplicationServices.API.Handlers.UserHandlers
{
    public class GetUserByLoginHandler : IRequestHandler<GetUserByLoginRequest, GetUserByLoginResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetUserByLoginHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }
        public async Task<GetUserByLoginResponse> Handle(GetUserByLoginRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUserByLoginQuery
            {
                Login = request.Login
            };
            var user = await queryExecutor.Execute(query);
            var mappedUser = mapper.Map<Domain.Models.User>(user);
            return new GetUserByLoginResponse
            {
                Data = mappedUser
            };
        }
    }
}
