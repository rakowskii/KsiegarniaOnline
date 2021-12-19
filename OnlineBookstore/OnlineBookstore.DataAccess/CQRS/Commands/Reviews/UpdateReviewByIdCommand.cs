using OnlineBookstore.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookstore.DataAccess.CQRS.Commands.Reviews
{
    public class UpdateReviewByIdCommand : CommandBase<Review, Review>
    {
        public override async Task<Review> Execute(BookstoreContext context)
        {
            context.Reviews.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
