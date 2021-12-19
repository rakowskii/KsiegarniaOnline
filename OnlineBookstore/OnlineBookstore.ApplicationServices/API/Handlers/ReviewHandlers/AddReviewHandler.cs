using AutoMapper;
using OnlineBookstore.ApplicationServices.API.Domain.Models;
using OnlineBookstore.ApplicationServices.API.Domain.ReviewRequests;
using OnlineBookstore.ApplicationServices.API.Domain.ReviewResponses;
using OnlineBookstore.DataAccess.CQRS;
using OnlineBookstore.DataAccess.CQRS.Commands.Reviews;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineBookstore.ApplicationServices.API.Handlers.ReviewHandlers
{
    public class AddReviewHandler : IRequestHandler<AddReviewRequest, AddReviewResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;
       

        public AddReviewHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }
            
            
        public async Task<AddReviewResponse> Handle(AddReviewRequest request, CancellationToken cancellationToken)
        {
            var review = mapper.Map<DataAccess.Entities.Review>(request);
            var command = new AddReviewCommand { Parameter = review };
            var reviewFromDb = await commandExecutor.Execute(command);
            
            var response = new AddReviewResponse
            {
                Data = mapper.Map<Review>(reviewFromDb)
            };

            
            return response;

           
            
        }
    }
}
