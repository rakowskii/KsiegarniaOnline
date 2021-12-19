using AutoMapper;
using OnlineBookstore.ApplicationServices.API.Domain.ReviewRequests;
using OnlineBookstore.ApplicationServices.API.Domain.ReviewResponses;
using OnlineBookstore.DataAccess.CQRS;
using OnlineBookstore.DataAccess.CQRS.Commands.Reviews;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineBookstore.ApplicationServices.API.Handlers.ReviewHandlers
{


    public class UpdateReviewByIdHandler : IRequestHandler<UpdateReviewByIdRequest, UpdateReviewByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public UpdateReviewByIdHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<UpdateReviewByIdResponse> Handle(UpdateReviewByIdRequest request, CancellationToken cancellationToken)
        {
            var review = mapper.Map<DataAccess.Entities.Review>(request);
            var command = new UpdateReviewByIdCommand { Parameter = review };
            var reviewFromDb = await commandExecutor.Execute(command);
            var mappedReview = mapper.Map<Domain.Models.Review>(reviewFromDb);
            return new UpdateReviewByIdResponse
            {
                Data = mappedReview
            };
        }
    }
}
