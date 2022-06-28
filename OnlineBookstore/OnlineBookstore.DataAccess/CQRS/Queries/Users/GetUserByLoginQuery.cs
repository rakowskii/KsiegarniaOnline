using Microsoft.EntityFrameworkCore;
using OnlineBookstore.DataAccess.Entities;
using System.Threading.Tasks;

namespace OnlineBookstore.DataAccess.CQRS.Queries.Users
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