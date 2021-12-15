using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using KsiegarniaOnline.ApplicationServices.API.Domain.ProductRequests;
using KsiegarniaOnline.ApplicationServices.API.Domain.ProductResponses;
using System.Threading;
using KsiegarniaOnline.DataAccess;
using KsiegarniaOnline.DataAccess.CQRS.Queries.Products;
using KsiegarniaOnline.ApplicationServices.API.Domain.Models;


namespace KsiegarniaOnline.ApplicationServices.API.Handlers.ProductHandlers
{
    public class GetProductByAuthorHandler : IRequestHandler<GetProductByAuthorRequest, GetProductByAuthorResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetProductByAuthorHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetProductByAuthorResponse> Handle(GetProductByAuthorRequest request, CancellationToken cancellationToken)
        {
            var query = new GetProductByAuthorQuery()
            {
                Author = request.ProductsAuthor
            };

            var products = await queryExecutor.Execute(query);
            var mappedProducts = mapper.Map<List<Product>>(products);

            return new GetProductByAuthorResponse
            {
                Data = mappedProducts
            };
            

        }
    }
}
