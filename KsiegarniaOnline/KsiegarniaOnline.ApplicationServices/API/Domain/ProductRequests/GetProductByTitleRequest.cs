using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using KsiegarniaOnline.ApplicationServices.API.Domain.ProductResponses;

namespace KsiegarniaOnline.ApplicationServices.API.Domain.ProductRequests
{
    public class GetProductByTitleRequest : IRequest<GetProductByTitleResponse>
    {
        public string ProductsTitle {get; set;}
    }
}
