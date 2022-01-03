using AutoMapper;
using OnlineBookstore.ApplicationServices.API.Domain.OrderRequests;
using OnlineBookstore.ApplicationServices.API.Domain.OrderResponses;
using OnlineBookstore.DataAccess;
using OnlineBookstore.DataAccess.CQRS.Queries.Orders;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using OnlineBookstore.ApplicationServices.API.Domain.ProductResponses;
using OnlineBookstore.ApplicationServices.API.Domain;
using OnlineBookstore.ApplicationServices.API.ErrorHandling;

namespace OnlineBookstore.ApplicationServices.API.Handlers.OrderHandlers
{
    public  class GetOrderByIdHandler : IRequestHandler<GetOrderByIdRequest, GetOrderByIdResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetOrderByIdHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetOrderByIdResponse> Handle(GetOrderByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetOrderByIdQuery
            {
                OrderId = request.OrderId
            };
            var order = await queryExecutor.Execute(query);
            if (order == null)
            {
                return new GetOrderByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedOrder = mapper.Map<Domain.Models.Order>(order);
            return new GetOrderByIdResponse
            {
                Data = mappedOrder
            };
        }
    }
}
