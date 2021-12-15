using KsiegarniaOnline.ApplicationServices.API.Domain.ReviewResponses;
using KsiegarniaOnline.DataAccess.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System;

namespace KsiegarniaOnline.ApplicationServices.API.Domain.ReviewRequests
{
    public class AddReviewRequest : IRequest<AddReviewResponse>
    {
        
        public int UserId { get; set; }
        public int ProductId { get; set; }

        [Required]
        public string Reviews { get; set; }

        [DataType(DataType.Date)]
        public DateTime AddDate { get; set; }


    }
}
