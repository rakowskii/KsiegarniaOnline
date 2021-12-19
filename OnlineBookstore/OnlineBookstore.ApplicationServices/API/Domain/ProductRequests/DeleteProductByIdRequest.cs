using OnlineBookstore.ApplicationServices.API.Domain.ProductResponses;
using OnlineBookstore.DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookstore.ApplicationServices.API.Domain.ProductRequests
{
   public class DeleteProductByIdRequest : IRequest<DeleteProductByIdResponse>
    {
        public int Id { get; set; }
    }
}
