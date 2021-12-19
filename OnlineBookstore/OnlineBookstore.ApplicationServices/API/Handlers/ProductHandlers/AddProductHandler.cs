using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineBookstore.ApplicationServices.API.Domain;
using OnlineBookstore.ApplicationServices.API.Domain.Models;
using System.Threading;
using OnlineBookstore.DataAccess.CQRS;
using OnlineBookstore.DataAccess.CQRS.Commands;
using AutoMapper;
using OnlineBookstore.ApplicationServices.API.Domain.ProductResponses;
using OnlineBookstore.ApplicationServices.API.Domain.ProductRequests;


namespace OnlineBookstore.ApplicationServices.API.Handlers.ProductHandlers
{
    class AddReviewHandler : IRequestHandler<AddProductRequest, AddProductResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddReviewHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }
        public async Task<AddProductResponse> Handle(AddProductRequest request, CancellationToken cancellationToken)
        {
            var product = mapper.Map<DataAccess.Entities.Product>(request);
            var command = new AddProductCommand { Parameter = product };
            var productFromDb = await commandExecutor.Execute(command);
            return new AddProductResponse
            {
                Data = mapper.Map<Product>(productFromDb)
            };





            
        }



    }
}
