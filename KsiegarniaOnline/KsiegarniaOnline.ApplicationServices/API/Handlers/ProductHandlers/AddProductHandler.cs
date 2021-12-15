using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KsiegarniaOnline.ApplicationServices.API.Domain;
using KsiegarniaOnline.ApplicationServices.API.Domain.Models;
using System.Threading;
using KsiegarniaOnline.DataAccess.CQRS;
using KsiegarniaOnline.DataAccess.CQRS.Commands;
using AutoMapper;
using KsiegarniaOnline.ApplicationServices.API.Domain.ProductResponses;
using KsiegarniaOnline.ApplicationServices.API.Domain.ProductRequests;


namespace KsiegarniaOnline.ApplicationServices.API.Handlers
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
