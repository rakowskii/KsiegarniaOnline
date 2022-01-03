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
using OnlineBookstore.ApplicationServices.API.Domain;
using OnlineBookstore.ApplicationServices.API.ErrorHandling;

namespace OnlineBookstore.ApplicationServices.API.Handlers.ProductHandlers
{
    public class GetProductByPublisherHandler : IRequestHandler<GetProductByPublisherRequest, GetProductByPublisherResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetProductByPublisherHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetProductByPublisherResponse> Handle(GetProductByPublisherRequest request, CancellationToken cancellationToken)
        {
            var query = new GetProductByPublisherQuery
            {
                Publisher = request.Publisher
            };
            var product = await queryExecutor.Execute(query);
            if (product == null)
            {
                return new GetProductByPublisherResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedProduct = mapper.Map<List<Domain.Models.Product>>(product);
            return new GetProductByPublisherResponse
            {
                Data = mappedProduct
            };
        }
    }
}
