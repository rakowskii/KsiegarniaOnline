using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OnlineBookstore.DataAccess.Entities.Product;
using OnlineBookstore.ApplicationServices.API.Domain.ProductResponses;

namespace OnlineBookstore.ApplicationServices.API.Domain.ProductRequests
{
   public class AddProductRequest : IRequest<AddProductResponse>
    {
        
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int Year { get; set; }
        public int Pages { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public bool IsBestseller { get; set; }
        public bool InStock { get; set; }
        public string Series { get; set; }
        public Types Type { get; set; }
        public Categories Category { get; set; }
        public Covers Cover { get; set; }
        
    }
}
