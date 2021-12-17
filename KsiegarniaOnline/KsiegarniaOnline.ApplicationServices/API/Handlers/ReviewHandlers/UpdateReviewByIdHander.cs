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
