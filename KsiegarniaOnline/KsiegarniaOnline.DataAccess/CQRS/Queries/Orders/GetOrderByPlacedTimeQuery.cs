using KsiegarniaOnline.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace KsiegarniaOnline.DataAccess.CQRS.Queries.Orders
{
    public class GetOrderByPlacedTimeQuery : QueryBase<List<Order>>
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public override async Task<List<Order>> Execute(BookstoreContext context)
        {
            return await context.Orders.Where(x => x.OrderPlaced >= From && x.OrderPlaced <= To).ToListAsync();
        }
    }
}
