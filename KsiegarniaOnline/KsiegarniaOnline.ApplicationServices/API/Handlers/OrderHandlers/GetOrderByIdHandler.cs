using AutoMapper;
using KsiegarniaOnline.ApplicationServices.API.Domain.OrderRequests;
using KsiegarniaOnline.ApplicationServices.API.Domain.OrderResponses;
using KsiegarniaOnline.DataAccess;
using KsiegarniaOnline.DataAccess.CQRS.Queries.Orders;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KsiegarniaOnline.ApplicationServices.API.Handlers.OrderHandlers
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
            var mappedOrder = mapper.Map<Domain.Models.Order>(order);
            return new GetOrderByIdResponse
            {
                Data = mappedOrder
            };
        }
    }
}
