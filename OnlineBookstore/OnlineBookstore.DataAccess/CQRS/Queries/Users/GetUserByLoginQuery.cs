using Microsoft.EntityFrameworkCore;
using OnlineBookstore.DataAccess.Entities;
using System.Threading.Tasks;

namespace OnlineBookstore.DataAccess.CQRS.Queries.Users
{
    public class GetUserByLoginQuery : QueryBase<User>
    {
        public string Username { get; set; }

        public override Task<User> Execute(BookstoreContext context)
        {
            return  context.Users.FirstOrDefaultAsync(x => x.Username == Username);
        }
    }
}