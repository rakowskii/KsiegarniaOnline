using AutoMapper;
using OnlineBookstore.ApplicationServices.API.Domain.Models;
using OnlineBookstore.ApplicationServices.API.Domain.OrderRequests;
using OnlineBookstore.ApplicationServices.API.Domain.OrderResponses;
using OnlineBookstore.DataAccess;
using OnlineBookstore.DataAccess.CQRS.Queries.Orders;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineBookstore.ApplicationServices.API.Handlers.OrderHandlers
{
    public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersRequest, GetAllOrdersResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetAllOrdersHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }
        public async Task<GetAllOrdersResponse> Handle(GetAllOrdersRequest request, CancellationToken cancellationToken)
        {
            var query = new GetAllOrdersQuery();
            var orders = await queryExecutor.Execute(query);
            var mappedOrder = mapper.Map<List<Order>>(orders);
            var response = new GetAllOrdersResponse()
            {
                Data = mappedOrder
            };
            return response;
        }
    }
}
