using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using KsiegarniaOnline.ApplicationServices.API.Domain.ProductRequests;
using KsiegarniaOnline.ApplicationServices.API.Domain.ProductResponses;
using KsiegarniaOnline.DataAccess;
using KsiegarniaOnline.DataAccess.CQRS.Queries.Products;
using MediatR;
using KsiegarniaOnline.ApplicationServices.API.Domain.Models;

namespace KsiegarniaOnline.ApplicationServices.API.Handlers.ProductHandlers
{
    public class GetProductBySeriesHandler : IRequestHandler<GetProductBySeriesRequest, GetProductBySeriesResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetProductBySeriesHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetProductBySeriesResponse> Handle(GetProductBySeriesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetProductBySeriesQuery()
            {
                Series = request.ProductsSeries
            };

            var products = await queryExecutor.Execute(query);
            var mappedProducts = mapper.Map<List<Product>>(products);

            return new GetProductBySeriesResponse
            {
                Data = mappedProducts
            };


        }

        
        
    }
}
