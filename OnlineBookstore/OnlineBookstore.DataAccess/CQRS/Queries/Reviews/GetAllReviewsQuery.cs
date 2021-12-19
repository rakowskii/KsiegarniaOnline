using OnlineBookstore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineBookstore.DataAccess.CQRS.Queries
{
    public class GetAllReviewsQuery : QueryBase<List<Review>>
    {
        public override Task<List<Review>> Execute(BookstoreContext context)
        {
            return context.Reviews.ToListAsync();
        }
    }
}
