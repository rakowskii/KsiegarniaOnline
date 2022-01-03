using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using OnlineBookstore.ApplicationServices.API.Domain.ProductRequests;
using OnlineBookstore.ApplicationServices.API.Domain.ProductResponses;
using OnlineBookstore.DataAccess;
using OnlineBookstore.DataAccess.CQRS.Queries.Products;
using MediatR;
using OnlineBookstore.ApplicationServices.API.Domain.Models;
using OnlineBookstore.ApplicationServices.API.Domain;
using OnlineBookstore.ApplicationServices.API.ErrorHandling;
using OnlineBookstore.DataAccess.Entities;

namespace OnlineBookstore.ApplicationServices.API.Handlers.ProductHandlers
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
            if (products == null)
            {
                return new GetProductBySeriesResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedProducts = mapper.Map<List<Domain.Models.Product>>(products);

            return new GetProductBySeriesResponse
            {
                Data = mappedProducts
            };


        }

        
        
    }
}
