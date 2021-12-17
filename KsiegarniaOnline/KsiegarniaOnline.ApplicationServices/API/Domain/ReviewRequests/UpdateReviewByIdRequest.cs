using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KsiegarniaOnline.ApplicationServices.API.Domain.ReviewResponses;
using MediatR;

namespace KsiegarniaOnline.ApplicationServices.API.Domain.ReviewRequests
{
    public class UpdateReviewByIdRequest : IRequest<UpdateReviewByIdResponse>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string Reviews { get; set; }
        
    }
}

       
