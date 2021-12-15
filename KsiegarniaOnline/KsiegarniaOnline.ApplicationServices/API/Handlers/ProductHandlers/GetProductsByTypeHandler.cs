using AutoMapper;
using KsiegarniaOnline.ApplicationServices.API.Domain.Models;
using KsiegarniaOnline.ApplicationServices.API.Domain.ProductRequests;
using KsiegarniaOnline.ApplicationServices.API.Domain.ProductResponses;
using KsiegarniaOnline.DataAccess;
using KsiegarniaOnline.DataAccess.CQRS.Queries.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace KsiegarniaOnline.ApplicationServices.API.Handlers.ProductHandlers
{
    public class GetProductByTypeHandler : IRequestHandler<GetProductByTypeRequest, GetProductByTypeResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetProductByTypeHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetProductByTypeResponse> Handle(GetProductByTypeRequest request, CancellationToken cancellationToken)
        {
            var query = new GetProductByTypeQuery()
            {
                Type = request.Type
            };

            var products = await queryExecutor.Execute(query);
            var mappedProducts = mapper.Map<List<Product>>(products);

            return new GetProductByTypeResponse
            {
                Data = mappedProducts
            };
        }
    }
}
