using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineBookstore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace OnlineBookstore.DataAccess.CQRS.Queries
{
    public class GetProductsQuery : QueryBase<List<Product>>
    {
        public override Task<List<Product>> Execute(BookstoreContext context)
        {
            return  context.Products
                .Include(x => x.Reviews)
                .ToListAsync();
        }
    }
}