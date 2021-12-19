using OnlineBookstore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace OnlineBookstore.DataAccess.CQRS.Queries.Orders
{
    public class GetOrderByTotalPriceQuery : QueryBase<List<Order>>
    {
        public decimal From { get; set; }
        public decimal To { get; set; }
        public override async Task<List<Order>> Execute(BookstoreContext context)
        {
            return await context.Orders.Where(x => x.OrderTotal >= From && x.OrderTotal <= To).ToListAsync();
        }
    }
}
