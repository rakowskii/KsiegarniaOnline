using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KsiegarniaOnline.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace KsiegarniaOnline.DataAccess.CQRS.Queries
{
    public class GetProductsQuery : QueryBase<List<Product>>
    {
        public override Task<List<Product>> Execute(BookstoreContext context)
        {
            return  context.Products.ToListAsync();
        }
    }
}
