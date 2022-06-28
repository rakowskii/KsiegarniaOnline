using OnlineBookstore.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookstore.DataAccess.CQRS.Commands.Products
{
    public class UpdateProductCommand : CommandBase<Product, Product>
    {
        public override async Task<Product> Execute(BookstoreContext context)
        {
            context.Products.Update(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}