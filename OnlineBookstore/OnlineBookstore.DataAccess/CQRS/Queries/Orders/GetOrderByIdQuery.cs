using OnlineBookstore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace OnlineBookstore.DataAccess.CQRS.Queries.Orders
{
    public class GetOrderByIdQuery : QueryBase<Order>
    {
        public int OrderId { get; set; }
        public override async Task<Order> Execute(BookstoreContext context)
        {
            return await context.Orders.FirstOrDefaultAsync(x => x.Id == OrderId);
        }
    }
}
