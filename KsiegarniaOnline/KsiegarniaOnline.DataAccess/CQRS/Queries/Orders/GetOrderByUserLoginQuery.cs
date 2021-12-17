using KsiegarniaOnline.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KsiegarniaOnline.DataAccess.CQRS.Queries.Orders
{
    public class GetOrderByUserLoginQuery : QueryBase<List<Order>>
    {
        public string Login { get; set; }
        public override async Task<List<Order>> Execute(BookstoreContext context)
        {
            return await context.Orders.Where(x => x.Users.Login == Login).ToListAsync();
        }
    }
}
