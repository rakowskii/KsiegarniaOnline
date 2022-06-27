using OnlineBookstore.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OnlineBookstore.DataAccess.CQRS.Commands.Products
{
    public class DeleteProductByIdCommand : CommandBase<Product, Product>
    {
        public override async Task<Product> Execute(BookstoreContext context)
        {
            context.Products.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}                          