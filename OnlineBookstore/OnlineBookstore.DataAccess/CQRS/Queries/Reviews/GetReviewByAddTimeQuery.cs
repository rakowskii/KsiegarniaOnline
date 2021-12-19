using OnlineBookstore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.DataAccess.CQRS.Queries
{
    public class GetReviewByAddTimeQuery : QueryBase<List<Review>>
    {
        public DateTime  From { get; set; }
        public DateTime  To { get; set; }

        public override async Task<List<Review>> Execute(BookstoreContext context)
        {
            if (From < To)
            {
                var reviews = context.Reviews.Where(x => x.AddDate >= From && x.AddDate <= To).ToListAsync();
                return await reviews;
            }
            else if(From > To)
            {
                var reviews = context.Reviews.Where(x => x.AddDate >= From && x.AddDate <= To).ToListAsync();
                return await reviews;
            }
            else
            {
                return await context.Reviews.Include(x => x.AddDate).ToListAsync();
            }
        }
    }
}

