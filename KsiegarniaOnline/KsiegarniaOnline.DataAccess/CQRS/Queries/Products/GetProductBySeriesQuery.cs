using KsiegarniaOnline.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KsiegarniaOnline.DataAccess.CQRS.Queries.Products
{
    public class GetProductBySeriesQuery : QueryBase<List<Product>>
    {
        public string Series { get; set; }
        public override async Task<List<Product>> Execute(BookstoreContext context)
        {
            var products = context.Products.Where(x => x.Series == Series).ToListAsync();
            return await products;
        }
    }
}
