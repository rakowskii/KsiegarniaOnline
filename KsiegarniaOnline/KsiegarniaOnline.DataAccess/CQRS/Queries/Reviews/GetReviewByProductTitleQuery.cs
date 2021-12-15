using KsiegarniaOnline.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KsiegarniaOnline.DataAccess.CQRS.Queries
{
    public class GetReviewByProductTitleQuery : QueryBase<List<Review>>
    {
        public string Title { get; set; }
        public override async Task<List<Review>> Execute(BookstoreContext context)
        {
            var reviews = context.Reviews.Where(x => x.Products.Title == Title).ToListAsync();
            return await reviews;
        }
    }
}
