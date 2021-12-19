using OnlineBookstore.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookstore.DataAccess.CQRS.Commands
{
    public class AddProductCommand : CommandBase<Product, Product>
    {
        public override async Task<Product> Execute(BookstoreContext context)
        {
            await context.Products.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
