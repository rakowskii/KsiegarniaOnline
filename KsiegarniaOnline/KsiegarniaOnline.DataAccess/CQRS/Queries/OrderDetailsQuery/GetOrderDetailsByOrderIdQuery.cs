using KsiegarniaOnline.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KsiegarniaOnline.DataAccess.CQRS.Queries.OrderDetailsQuery
{
    public class GetOrderDetailsByOrderIdQuery : QueryBase<List<OrderDetail>>
    {
        public int OrderId { get; set; }
        public override async Task<List<OrderDetail>> Execute(BookstoreContext context)
        {
            return await context.OrderDetails.Where(x => x.OrderId == OrderId).ToListAsync();
        }
    }
}
