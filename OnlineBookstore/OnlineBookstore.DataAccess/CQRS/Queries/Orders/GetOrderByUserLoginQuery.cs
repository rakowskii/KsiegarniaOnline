﻿using OnlineBookstore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.DataAccess.CQRS.Queries.Orders
{
    public class GetOrderByUserLoginQuery : QueryBase<List<Order>>
    {
        public string Username { get; set; }
        public override async Task<List<Order>> Execute(BookstoreContext context)
        {
            return await context.Orders.Where(x => x.Users.Username == Username).ToListAsync();
        }
    }
}
