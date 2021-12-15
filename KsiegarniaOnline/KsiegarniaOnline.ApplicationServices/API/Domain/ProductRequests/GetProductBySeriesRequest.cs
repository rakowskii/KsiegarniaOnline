using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KsiegarniaOnline.ApplicationServices.API.Domain.ProductResponses;
using MediatR;


namespace KsiegarniaOnline.ApplicationServices.API.Domain.ProductRequests
{
    public class GetProductBySeriesRequest : IRequest<GetProductBySeriesResponse>
    {
        public string ProductsSeries { get; set; }
    }
}
