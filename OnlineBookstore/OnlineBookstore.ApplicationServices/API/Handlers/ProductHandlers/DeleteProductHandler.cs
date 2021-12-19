using AutoMapper;
using OnlineBookstore.ApplicationServices.API.Domain.ProductRequests;
using OnlineBookstore.ApplicationServices.API.Domain.ProductResponses;
using OnlineBookstore.DataAccess.CQRS;
using OnlineBookstore.DataAccess.CQRS.Commands.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineBookstore.ApplicationServices.API.Handlers.ProductHandlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductByIdRequest, DeleteProductByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public DeleteProductHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }
        public async Task<DeleteProductByIdResponse> Handle(DeleteProductByIdRequest request, CancellationToken cancellationToken)
        {
            var product = mapper.Map<DataAccess.Entities.Product>(request);
            var command = new DeleteProductByIdCommand { Parameter = product };
            var productFromDb = await commandExecutor.Execute(command);
            var mappedProduct = mapper.Map<Domain.Models.Product>(productFromDb);
            return new DeleteProductByIdResponse
            {
                Data = mappedProduct
            };
            
        }
    }
}
