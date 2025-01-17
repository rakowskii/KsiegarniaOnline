﻿using OnlineBookstore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.DataAccess.CQRS.Queries
{
    public class GetReviewByUserLoginQuery : QueryBase<List<Review>>
    {
        public string Username { get; set; }
        public override async Task<List<Review>> Execute(BookstoreContext context)
        {
            var reviews = context.Reviews.Where(x => x.Users.Username == Username).ToListAsync();
            return await reviews;
        }
    }
}
