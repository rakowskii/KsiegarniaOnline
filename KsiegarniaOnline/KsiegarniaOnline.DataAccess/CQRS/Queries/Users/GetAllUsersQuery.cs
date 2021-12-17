using KsiegarniaOnline.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KsiegarniaOnline.DataAccess.CQRS.Queries.Users
{
    public class GetAllUsersQuery : QueryBase<List<User>>
    {
        public override async Task<List<User>> Execute(BookstoreContext context)
        {
            return await context.Users.ToListAsync();
        }
    }
}
