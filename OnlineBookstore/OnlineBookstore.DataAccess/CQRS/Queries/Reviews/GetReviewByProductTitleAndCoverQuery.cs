using OnlineBookstore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.DataAccess.CQRS.Queries
{
    public class GetReviewByProductTitleAndCoverQuery : QueryBase<List<Review>>
    {
        public string Title { get; set; }
        public Product.Covers Cover { get; set; }
        public override async Task<List<Review>> Execute(BookstoreContext context)
        {
            var reviews = context.Reviews.Where(x => x.Products.Title == Title && x.Products.Cover == Cover).ToListAsync();
            return await reviews;
        }
    }
}
