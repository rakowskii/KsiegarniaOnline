using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KsiegarniaOnline.ApplicationServices.API.Domain.ReviewResponses;
using MediatR;

namespace KsiegarniaOnline.ApplicationServices.API.Domain.ReviewRequests
{
   public class DeleteReviewByIdRequest : IRequest<DeleteReviewByIdResponse>
    {
        public int ReviewId { get; set; }
    }
}
