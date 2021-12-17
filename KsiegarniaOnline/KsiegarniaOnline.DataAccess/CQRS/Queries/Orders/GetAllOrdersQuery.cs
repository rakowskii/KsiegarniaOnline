using KsiegarniaOnline.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KsiegarniaOnline.DataAccess.CQRS.Queries.Orders
{
    public class GetAllOrdersQuery : QueryBase<List<Order>>
    {
        public override async Task<List<Order>> Execute(BookstoreContext context)
        {
            return await context.Orders.ToListAsync();
        }
    }
}
