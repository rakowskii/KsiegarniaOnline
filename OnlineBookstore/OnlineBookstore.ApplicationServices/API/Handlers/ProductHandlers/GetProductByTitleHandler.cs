using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using OnlineBookstore.ApplicationServices.API.Domain.ProductResponses;
using OnlineBookstore.ApplicationServices.API.Domain.ProductRequests;
using OnlineBookstore.DataAccess.CQRS.Queries;
using System.Threading;
using OnlineBookstore.DataAccess;
using OnlineBookstore.ApplicationServices.API.Domain.Models;
using OnlineBookstore.ApplicationServices.API.Domain;
using OnlineBookstore.ApplicationServices.API.ErrorHandling;

namespace OnlineBookstore.ApplicationServices.API.Handlers.ProductHandlers
{
    class GetProductByTitleHandler : IRequestHandler<GetProductByTitleRequest, GetProductByTitleResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetProductByTitleHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetProductByTitleResponse> Handle(GetProductByTitleRequest request, CancellationToken cancellationToken)
        {
            var query = new GetProductByTitleQuery()
            {
                Title = request.ProductsTitle
            };

            var products = await queryExecutor.Execute(query);
            if (products == null)
            {
                return new GetProductByTitleResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            return new GetProductByTitleResponse
            {
                Data = mapper.Map<List<Product>>(products)
            };

            
        }
    }
}
