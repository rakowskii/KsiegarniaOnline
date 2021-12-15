using KsiegarniaOnline.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KsiegarniaOnline.DataAccess.CQRS.Queries.Products
{
    public class GetProductByTypeQuery : QueryBase<List<Product>>
    {
        public Product.Types Type { get; set; }
        public async override Task<List<Product>> Execute(BookstoreContext context)
        {
            var products = context.Products.Where(x => x.Type == Type).ToListAsync();
            return await products;
        }
    }
}
