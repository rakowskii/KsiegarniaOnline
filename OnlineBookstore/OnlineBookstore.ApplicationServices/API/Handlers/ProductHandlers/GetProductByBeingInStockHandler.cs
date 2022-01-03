using AutoMapper;
using OnlineBookstore.ApplicationServices.API.Domain.Models;
using OnlineBookstore.ApplicationServices.API.Domain.ProductRequests;
using OnlineBookstore.ApplicationServices.API.Domain.ProductResponses;
using OnlineBookstore.DataAccess;
using OnlineBookstore.DataAccess.CQRS.Queries.Products;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OnlineBookstore.ApplicationServices.API.Domain;
using OnlineBookstore.ApplicationServices.API.ErrorHandling;

namespace OnlineBookstore.ApplicationServices.API.Handlers.ProductHandlers
{
    public class GetProductByBeingInStockHandler : IRequestHandler<GetProductByBeingInStockRequest, GetProductByBeingInStockResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetProductByBeingInStockHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetProductByBeingInStockResponse> Handle(GetProductByBeingInStockRequest request, CancellationToken cancellationToken)
        {
            var query = new GetProductByBeingInStockQuery();
            var products = await queryExecutor.Execute(query);
            if (products == null)
            {
                return new GetProductByBeingInStockResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedProducts = mapper.Map<List<Product>>(products);

            return new GetProductByBeingInStockResponse
            {
                Data = mappedProducts
            };
        }
    }
}
