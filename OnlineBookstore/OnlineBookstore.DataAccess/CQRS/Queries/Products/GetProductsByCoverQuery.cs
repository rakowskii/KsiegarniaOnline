using OnlineBookstore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.DataAccess.CQRS.Queries.Products
{
    public class GetProductByCoverQuery : QueryBase<List<Product>>
    {
        public Product.Covers Cover{ get; set; }
        public async override Task<List<Product>> Execute(BookstoreContext context)
        {
            var products = context.Products.Where(x => x.Cover == Cover).ToListAsync();
            return await products;
        }
    }
}
