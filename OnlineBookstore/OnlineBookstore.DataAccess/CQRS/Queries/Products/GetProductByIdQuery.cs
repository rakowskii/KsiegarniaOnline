using OnlineBookstore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookstore.DataAccess.CQRS.Queries
{
    public class GetProductByIdQuery : QueryBase<Product>
    {
        public int Id { get; set; }
        public override async Task<Product> Execute(BookstoreContext context)
        {
            var product = await context.Products
                .Include(x => x.Reviews)
                .FirstOrDefaultAsync(x => x.Id == this.Id);
            return product;
        }
    }
}
