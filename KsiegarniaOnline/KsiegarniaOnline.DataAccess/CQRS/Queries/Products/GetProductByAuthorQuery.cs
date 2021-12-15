using KsiegarniaOnline.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KsiegarniaOnline.DataAccess.CQRS.Queries.Products
{
    public class GetProductByAuthorQuery : QueryBase<List<Product>>
    {
        public string Author { get; set; }

        public override async Task<List<Product>> Execute(BookstoreContext context)
        {
            var product = context.Products.Where(x => x.Author.Contains(Author)).ToListAsync();
            return await product;
        }

    }
}
