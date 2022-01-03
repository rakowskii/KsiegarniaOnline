using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineBookstore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace OnlineBookstore.DataAccess.CQRS.Queries
{
    public class GetProductByTitleQuery : QueryBase<List<Product>>
    {
        public string Title { get; set; }
        public override async Task<List<Product>> Execute(BookstoreContext context)
        {
            var products = context.Products
                .Where(x => x.Title.Contains(Title))
                .Include(x => x.Reviews)
                .ToListAsync();
            return await products;
        }
    }
}
