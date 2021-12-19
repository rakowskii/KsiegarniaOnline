using AutoMapper;
using OnlineBookstore.ApplicationServices.API.Domain.OrderRequests;
using OnlineBookstore.ApplicationServices.API.Domain.OrderResponses;
using OnlineBookstore.DataAccess;
using OnlineBookstore.DataAccess.CQRS.Queries.Orders;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace OnlineBookstore.ApplicationServices.API.Handlers.OrderHandlers
{
    public class GetOrderByUserLoginHandler : IRequestHandler<GetOrderByUserLoginRequest, GetOrderByUserLoginResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetOrderByUserLoginHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetOrderByUserLoginResponse> Handle(GetOrderByUserLoginRequest request, CancellationToken cancellationToken)
        {
            var query = new GetOrderByUserLoginQuery
            {
                Login = request.UserLogin
            };
            var order = await queryExecutor.Execute(query);
            var mappedOrder = mapper.Map<List<Domain.Models.Order>>(order);
            return new GetOrderByUserLoginResponse
            {
                Data = mappedOrder
            };
        }
    }
}