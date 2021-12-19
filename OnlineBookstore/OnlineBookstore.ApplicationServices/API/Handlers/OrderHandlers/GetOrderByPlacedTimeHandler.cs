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
    public class GetOrderByPlacedTimeHandler : IRequestHandler<GetOrderByPlacedTimeRequest, GetOrderByPlacedTimeResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetOrderByPlacedTimeHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetOrderByPlacedTimeResponse> Handle(GetOrderByPlacedTimeRequest request, CancellationToken cancellationToken)
        {
            var query = new GetOrderByPlacedTimeQuery
            {
                From = request.From,
                To = request.To
            };
            var order = await queryExecutor.Execute(query);
            var mappedOrder = mapper.Map<List<Domain.Models.Order>>(order);
            return new GetOrderByPlacedTimeResponse
            {
                Data = mappedOrder
            };
        }
    }
}