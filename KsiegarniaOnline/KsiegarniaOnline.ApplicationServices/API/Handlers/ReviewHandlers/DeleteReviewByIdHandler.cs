using AutoMapper;
using KsiegarniaOnline.ApplicationServices.API.Domain.ReviewRequests;
using KsiegarniaOnline.ApplicationServices.API.Domain.ReviewResponses;
using KsiegarniaOnline.DataAccess.CQRS;
using KsiegarniaOnline.DataAccess.CQRS.Commands.Reviews;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KsiegarniaOnline.ApplicationServices.API.Handlers.ReviewHandlers
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
