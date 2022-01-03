using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnlineBookstore.ApplicationServices.API.Domain.ProductRequests;
using OnlineBookstore.ApplicationServices.API.Domain.ProductResponses;
using OnlineBookstore.DataAccess;
using OnlineBookstore.DataAccess.CQRS.Queries;
using AutoMapper;
using System.Threading;
using OnlineBookstore.ApplicationServices.API.Domain.Models;
using OnlineBookstore.ApplicationServices.API.ErrorHandling;
using OnlineBookstore.ApplicationServices.API.Domain;

namespace OnlineBookstore.ApplicationServices.API.Handlers.ProductHandlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdRequest, GetProductByIdResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetProductByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        
        public async Task<GetProductByIdResponse> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetProductByIdQuery
            {
                Id = request.ProductsId
            };
            var product = await queryExecutor.Execute(query);
            if(product == null)
            {
                return new GetProductByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedProduct = mapper.Map<Product>(product);
            return new GetProductByIdResponse
            {
                Data = mappedProduct
            };
           
        }
    }
}


