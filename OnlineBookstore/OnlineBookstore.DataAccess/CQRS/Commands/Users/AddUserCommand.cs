using OnlineBookstore.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookstore.DataAccess.CQRS.Commands.Users
{
    public class AddUserCommand : CommandBase<User, User>
    {
        public override async Task<User> Execute(BookstoreContext context)
        {
            await context.Users.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;


        }
    }
}
