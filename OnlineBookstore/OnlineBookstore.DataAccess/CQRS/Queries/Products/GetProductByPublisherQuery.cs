using OnlineBookstore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.DataAccess.CQRS.Queries.Products
{
    public class GetProductByPublisherQuery : QueryBase<List<Product>>
    {
        public string Publisher { get; set; }

        public override async Task<List<Product>> Execute(BookstoreContext context)
        {
            var product = context.Products.Where(x => x.Publisher == Publisher).ToListAsync();
            return await product;
        }

    }
}
