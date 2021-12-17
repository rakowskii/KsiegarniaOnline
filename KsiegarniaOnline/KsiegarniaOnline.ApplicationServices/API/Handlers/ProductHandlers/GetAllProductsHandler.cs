using AutoMapper;
using KsiegarniaOnline.ApplicationServices.API.Domain;
using KsiegarniaOnline.DataAccess;
using KsiegarniaOnline.DataAccess.CQRS.Queries;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KsiegarniaOnline.ApplicationServices.API.Domain.ProductResponses;
using KsiegarniaOnline.ApplicationServices.API.Domain.ProductRequests;
using KsiegarniaOnline.ApplicationServices.API.Domain.Models;



namespace KsiegarniaOnline.ApplicationServices.API.Handlers.ProductHandlers
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
            

         

           











