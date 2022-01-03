using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using OnlineBookstore.ApplicationServices.API.Domain.ProductResponses;
using OnlineBookstore.ApplicationServices.API.Domain.ProductRequests;
using System.Threading;
using OnlineBookstore.DataAccess;
using OnlineBookstore.DataAccess.CQRS.Queries.Products;
using OnlineBookstore.ApplicationServices.API.Domain.Models;
using OnlineBookstore.ApplicationServices.API.Domain;
using OnlineBookstore.ApplicationServices.API.ErrorHandling;
using OnlineBookstore.DataAccess.Entities;

namespace OnlineBookstore.ApplicationServices.API.Handlers.ProductHandlers
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
            if (productsFromDb == null)
            {
                return new GetProductByPriceResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var response = new GetProductByPriceResponse
            {
                Data = mapper.Map<List<Domain.Models.Product>>(productsFromDb)
            };
            return response;
        }
    }
}

         
