using AutoMapper;
using KsiegarniaOnline.ApplicationServices.API.Domain.UserRequests;
using KsiegarniaOnline.ApplicationServices.API.Domain.UserResponses;
using KsiegarniaOnline.DataAccess;
using KsiegarniaOnline.DataAccess.CQRS;
using KsiegarniaOnline.DataAccess.CQRS.Commands.Users;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KsiegarniaOnline.ApplicationServices.API.Handlers.UserHandlers
{
    public class AddUserHandler : IRequestHandler<AddUserRequest, AddUserResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddUserHandler(ICommandExecutor queryExecutor, IMapper mapper)
        {
            this.commandExecutor = queryExecutor;
            this.mapper = mapper;
        }
        public async Task<AddUserResponse> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
            var user = mapper.Map<DataAccess.Entities.User>(request);
            var command = new AddUserCommand { Parameter = user };
            var userFromDb = await commandExecutor.Execute(command);
            var mappedUser = mapper.Map<Domain.Models.User>(userFromDb);
            return new AddUserResponse
            {
                Data = mappedUser
            };
        }
    }
}
