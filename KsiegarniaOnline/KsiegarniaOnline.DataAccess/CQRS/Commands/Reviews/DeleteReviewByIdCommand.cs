using KsiegarniaOnline.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KsiegarniaOnline.DataAccess.CQRS.Commands.Reviews
{
    public class DeleteReviewByIdCommand : CommandBase<Review, Review>
    {
        public override async Task<Review> Execute(BookstoreContext context)
        {
            context.Reviews.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;


        }
    }
}
