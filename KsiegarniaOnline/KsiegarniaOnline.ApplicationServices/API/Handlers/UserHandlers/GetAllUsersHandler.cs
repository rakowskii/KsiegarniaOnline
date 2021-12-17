using AutoMapper;
using KsiegarniaOnline.ApplicationServices.API.Domain.UserRequests;
using KsiegarniaOnline.ApplicationServices.API.Domain.UserResponses;
using KsiegarniaOnline.DataAccess;
using KsiegarniaOnline.DataAccess.CQRS.Queries.Users;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KsiegarniaOnline.ApplicationServices.API.Handlers.UserHandlers
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
            var mappedUser = mapper.Map<List<Domain.Models.User>>(user);
            return new GetAllUsersResponse
            {
                Data = mappedUser
            };
        }
    }
}
            