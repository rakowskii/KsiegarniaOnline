﻿using OnlineBookstore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookstore.DataAccess.CQRS.Queries.Products
{
    public class GetProductByPriceQuery : QueryBase<List<Product>>
    {
        public decimal PriceFrom { get; set; }
        public decimal PriceTo { get; set; }

        public override async Task<List<Product>> Execute(BookstoreContext context)
        {
            
            if(PriceFrom < PriceTo)
            {
                var products = context.Products
                    .Where(x => x.Price >= PriceFrom && x.Price <= PriceTo)
                    .Include(x => x.Reviews)
                    .ToListAsync();
                return await products;
            }
            else if(PriceFrom > PriceTo)
            {
                var products = context.Products
                    .Where(x => x.Price <= PriceFrom && x.Price >= PriceTo)
                    .Include(x => x.Reviews)
                    .ToListAsync();
                return await products;
            }
            else
            {
                var products = context.Products
                    .Where(x => x.Price == PriceFrom)
                    .Include(x => x.Reviews)
                    .ToListAsync();
                return await products;
            }
        }
    }
}
