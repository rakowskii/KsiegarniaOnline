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
using Microsoft.Extensions.Logging;

namespace OnlineBookstore.ApplicationServices.API.Handlers.UserHandlers
{
    public class GetUserByLoginHandler : IRequestHandler<GetUserByLoginRequest, GetUserByLoginResponse>
    {
        private readonly IQueryExecutor _queryExecutor;
        private readonly IMapper _mapper;
        private readonly ILogger<GetUserByLoginHandler> _logger;

        public GetUserByLoginHandler(IQueryExecutor queryExecutor, IMapper mapper, ILogger<GetUserByLoginHandler> logger)
        {
            _queryExecutor = queryExecutor;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<GetUserByLoginResponse> Handle(GetUserByLoginRequest request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                _logger.LogInformation("CancellationToken was received");
            }
            var query = new GetUserByLoginQuery
            {
                Username = request.Username
            };
            var user = await _queryExecutor.Execute(query);
            if (user == null)
            {
                return new GetUserByLoginResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedUser = _mapper.Map<Domain.Models.User>(user);
            return new GetUserByLoginResponse
            {
                Data = mappedUser
            };
        }
    }
}
