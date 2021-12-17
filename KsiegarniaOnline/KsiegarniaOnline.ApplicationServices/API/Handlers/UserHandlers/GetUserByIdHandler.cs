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
            var mappedUser = mapper.Map<Domain.Models.User>(user);
            return new GetUserByIdResponse
            {
                Data = mappedUser
            };
        }
    }
}