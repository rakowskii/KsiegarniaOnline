using AutoMapper;
using KsiegarniaOnline.ApplicationServices.API.Domain.Models;
using KsiegarniaOnline.ApplicationServices.API.Domain.ProductRequests;
using KsiegarniaOnline.ApplicationServices.API.Domain.ProductResponses;
using KsiegarniaOnline.DataAccess;
using KsiegarniaOnline.DataAccess.CQRS.Queries.Products;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KsiegarniaOnline.ApplicationServices.API.Handlers.ProductHandlers
{
    public class GetProductByCategoryHandler : IRequestHandler<GetProductByCategoryRequest, GetProductByCategoryResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetProductByCategoryHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetProductByCategoryResponse> Handle(GetProductByCategoryRequest request, CancellationToken cancellationToken)
        {
            var query = new GetProductByCategoryQuery()
            {
                Category = request.Category
            };

            var products = await queryExecutor.Execute(query);
            var mappedProducts = mapper.Map<List<Product>>(products);

            return new GetProductByCategoryResponse
            {
                Data = mappedProducts
            };
        }
    }
}
