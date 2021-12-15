using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using KsiegarniaOnline.ApplicationServices.API.Domain.ProductResponses;
using KsiegarniaOnline.ApplicationServices.API.Domain.ProductRequests;
using System.Threading;
using KsiegarniaOnline.DataAccess;
using KsiegarniaOnline.DataAccess.CQRS.Queries.Products;
using KsiegarniaOnline.ApplicationServices.API.Domain.Models;

namespace KsiegarniaOnline.ApplicationServices.API.Handlers.ProductHandlers
{
    public class GetProductByPriceHandler : IRequestHandler<GetProductByPriceRequest, GetProductByPriceResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetProductByPriceHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetProductByPriceResponse> Handle(GetProductByPriceRequest request, CancellationToken cancellationToken)
        {
            var query = new GetProductByPriceQuery()
            {
                PriceFrom = request.PriceFrom,
                PriceTo = request.PriceTo
            };
            var productsFromDb = await queryExecutor.Execute(query);
            var response = new GetProductByPriceResponse
            {
                Data = mapper.Map<List<Product>>(productsFromDb)
            };
            return response;
        }
    }
}

         
