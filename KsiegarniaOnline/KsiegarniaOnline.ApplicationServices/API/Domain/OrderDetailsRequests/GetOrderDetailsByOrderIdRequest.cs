using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KsiegarniaOnline.ApplicationServices.API.Domain.OrderDetailsResponses;
using MediatR;

namespace KsiegarniaOnline.ApplicationServices.API.Domain.OrderDetailsRequests
{
    public class GetOrderDetailsByOrderIdRequest : IRequest<GetOrderDetailsByOrderIdResponse>
    {
        public int OrderId { get; set; }
    }
}
