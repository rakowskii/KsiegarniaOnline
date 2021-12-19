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


    public class DeleteReviewByIdHandler : IRequestHandler<DeleteReviewByIdRequest, DeleteReviewByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public DeleteReviewByIdHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<DeleteReviewByIdResponse> Handle(DeleteReviewByIdRequest request, CancellationToken cancellationToken)
        {
            var review = mapper.Map<DataAccess.Entities.Review>(request);
            var command = new DeleteReviewByIdCommand { Parameter = review };
            var reviewFromDb = await commandExecutor.Execute(command);
            var mappedReview = mapper.Map<Domain.Models.Review>(reviewFromDb);
            return new DeleteReviewByIdResponse
            {
                Data = mappedReview
            };
        }
    }
}
