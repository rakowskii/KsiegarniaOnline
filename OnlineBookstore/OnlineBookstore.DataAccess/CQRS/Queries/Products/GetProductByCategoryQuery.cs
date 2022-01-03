using OnlineBookstore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.DataAccess.CQRS.Queries.Products
{
    public class GetProductByCategoryQuery : QueryBase<List<Product>>
    {
        public Product.Categories Category { get; set; }
        public async override Task<List<Product>> Execute(BookstoreContext context)
        {
            var products = context.Products
                .Where(x => x.Category == Category)
                .Include(x => x.Reviews)
                .ToListAsync();
            return await products;
        }
    }
}
