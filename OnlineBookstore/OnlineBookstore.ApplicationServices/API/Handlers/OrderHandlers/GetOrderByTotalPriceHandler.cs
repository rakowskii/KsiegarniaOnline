using AutoMapper;
using OnlineBookstore.ApplicationServices.API.Domain.OrderRequests;
using OnlineBookstore.ApplicationServices.API.Domain.OrderResponses;
using OnlineBookstore.DataAccess;
using OnlineBookstore.DataAccess.CQRS.Queries.Orders;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using OnlineBookstore.ApplicationServices.API.Domain;
using OnlineBookstore.ApplicationServices.API.ErrorHandling;

namespace OnlineBookstore.ApplicationServices.API.Handlers.OrderHandlers
{
    public class GetOrderByTotalPriceHandler : IRequestHandler<GetOrderByTotalPriceRequest, GetOrderByTotalPriceResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetOrderByTotalPriceHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetOrderByTotalPriceResponse> Handle(GetOrderByTotalPriceRequest request, CancellationToken cancellationToken)
        {
            var query = new GetOrderByTotalPriceQuery
            {
                From = request.From,
                To = request.To
            };
            var order = await queryExecutor.Execute(query);
            if (order == null)
            {
                return new GetOrderByTotalPriceResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedOrder = mapper.Map<List<Domain.Models.Order>>(order);
            return new GetOrderByTotalPriceResponse
            {
                Data = mappedOrder
            };
        }
    }
}