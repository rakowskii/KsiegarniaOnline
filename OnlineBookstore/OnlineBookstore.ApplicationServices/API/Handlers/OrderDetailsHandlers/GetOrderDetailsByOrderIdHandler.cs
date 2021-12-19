using AutoMapper;
using OnlineBookstore.ApplicationServices.API.Domain.OrderDetailsRequests;
using OnlineBookstore.ApplicationServices.API.Domain.OrderDetailsResponses;
using OnlineBookstore.DataAccess;
using OnlineBookstore.DataAccess.CQRS.Queries.OrderDetailsQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineBookstore.ApplicationServices.API.Handlers.OrderDetailsHandlers
{
    public class GetOrderDetailsByOrderIdHandler : IRequestHandler<GetOrderDetailsByOrderIdRequest, GetOrderDetailsByOrderIdResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetOrderDetailsByOrderIdHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetOrderDetailsByOrderIdResponse> Handle(GetOrderDetailsByOrderIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetOrderDetailsByOrderIdQuery
            {
                OrderId = request.OrderId
            };
            var orderDetails = await queryExecutor.Execute(query);
            var mappedOrderDetails = mapper.Map<List<Domain.Models.OrderDetail>>(orderDetails);
            return new GetOrderDetailsByOrderIdResponse
            {
                Data = mappedOrderDetails
            };
        }
        
    }
        
}
        

        


        
    
