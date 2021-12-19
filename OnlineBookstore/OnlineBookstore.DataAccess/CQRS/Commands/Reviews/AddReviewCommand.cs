using OnlineBookstore.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookstore.DataAccess.CQRS.Commands.Reviews
{
    public class AddReviewCommand : CommandBase<Review, Review>
    {
        
        public override async Task<Review> Execute(BookstoreContext context)
        {
            await context.Reviews.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
