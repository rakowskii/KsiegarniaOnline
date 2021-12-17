using KsiegarniaOnline.ApplicationServices.API.Domain.ProductResponses;
using KsiegarniaOnline.DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KsiegarniaOnline.ApplicationServices.API.Domain.ProductRequests
{
   public class DeleteProductByIdRequest : IRequest<DeleteProductByIdResponse>
    {
        public int Id { get; set; }
    }
}
