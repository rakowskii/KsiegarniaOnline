using KsiegarniaOnline.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KsiegarniaOnline.DataAccess.CQRS.Commands.Products
{
    public class UpdateProductCommand : CommandBase<Product, Product>
    {
        public override async Task<Product> Execute(BookstoreContext context)
        {
            context.Products.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
