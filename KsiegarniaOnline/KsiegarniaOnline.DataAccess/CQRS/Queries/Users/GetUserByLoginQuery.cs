using KsiegarniaOnline.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KsiegarniaOnline.DataAccess.CQRS.Queries.Users
{
    public class GetUserByLoginQuery : QueryBase<User>
    {
        public string Login { get; set; }

        public override async Task<User> Execute(BookstoreContext context)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.Login == Login);
        }
    }
}
