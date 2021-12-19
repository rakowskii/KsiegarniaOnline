using AutoMapper;
using OnlineBookstore.ApplicationServices.API.Domain;
using OnlineBookstore.DataAccess;
using OnlineBookstore.DataAccess.CQRS.Queries;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using OnlineBookstore.ApplicationServices.API.Domain.ProductResponses;
using OnlineBookstore.ApplicationServices.API.Domain.ProductRequests;
using OnlineBookstore.ApplicationServices.API.Domain.Models;



namespace OnlineBookstore.ApplicationServices.API.Handlers.ProductHandlers
{
    public class GetAllProductsHandler : IRequestHandler<GetProductsRequest, GetProductsResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetAllProductsHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }
        public async Task<GetProductsResponse> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetProductsQuery();
            var products = await queryExecutor.Execute(query);
            var mappedProduct = this.mapper.Map<List<Product>>(products);  
            var response = new GetProductsResponse()
            {
                Data = mappedProduct
            };
            return response;
        }
    }
}
            

         

           











