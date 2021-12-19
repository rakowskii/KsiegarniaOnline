using OnlineBookstore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookstore.DataAccess.CQRS.Queries.Users
{
    public class GetUserByIdQuery : QueryBase<User>
    {
        public int Id { get; set; }
        public override async Task<User> Execute(BookstoreContext context)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.Id == Id);
        }
    }
}
