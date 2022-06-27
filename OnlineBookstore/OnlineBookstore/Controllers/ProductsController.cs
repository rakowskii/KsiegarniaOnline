using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.ApplicationServices.API.Domain.ProductRequests;
using OnlineBookstore.ApplicationServices.API.Domain.ProductResponses;
using MediatR;
using OnlineBookstore.DataAccess.Entities;


namespace OnlineBookstore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ApiControllerBase
    {
        
        public ProductsController(IMediator mediator) : base(mediator)
        {
        }
            
        

        [HttpGet]
        [Route("GetAll")]
        public Task<IActionResult> GetAllProducts([FromQuery] GetProductsRequest request)
        {
           return this.HandleRequest<GetProductsRequest, GetProductsResponse>(request);
        }

        [HttpGet]
        [Route("GetById/{id}")]

        public Task<IActionResult> GetProductById([FromRoute] int id)
        {
            var request = new GetProductByIdRequest()
            {
                ProductsId = id
            };
            return this.HandleRequest<GetProductByIdRequest, GetProductByIdResponse>(request);

        }

        [HttpGet]
        [Route("GetByTitle/{title}")]

        public Task<IActionResult> GetProductByTitle([FromRoute] string title)
        {
            var request = new GetProductByTitleRequest()
            {
                ProductsTitle = title
            };
            return this.HandleRequest<GetProductByTitleRequest, GetProductByTitleResponse>(request);

        }

        [HttpGet]
        [Route("GetByAuthor/{author}")]

        public Task<IActionResult> GetProductByAuthor([FromRoute] string author)
        {
            var request = new GetProductByAuthorRequest()
            {
                ProductsAuthor = author
            };
            return this.HandleRequest<GetProductByAuthorRequest, GetProductByAuthorResponse>(request);
        }

        [HttpGet]
        [Route("GetBySeries/{series}")]

        public Task<IActionResult> GetProductBySeries([FromRoute] string series)
        {
            var request = new GetProductBySeriesRequest()
            {
                ProductsSeries = series
            };
            return this.HandleRequest<GetProductBySeriesRequest, GetProductBySeriesResponse>(request);
        }

        [HttpGet]
        [Route("GetByType/{type}")]

        public Task<IActionResult> GetProductByType([FromRoute] Product.Types type)
        {
            var request = new GetProductByTypeRequest()
            {
                Type = type
            };
            return this.HandleRequest<GetProductByTypeRequest, GetProductByTypeResponse>(request);
        }

        [HttpGet]
        [Route("GetByBeingBestseller")]

        public Task<IActionResult> GetProductByBeingBestseller([FromQuery] GetProductByBeingBestsellerRequest request)
        {
            return this.HandleRequest<GetProductByBeingBestsellerRequest, GetProductByBeingBestsellerResponse>(request);
        }

        [HttpGet]
        [Route("GetByBeingInStock")]

        public Task<IActionResult> GetProductByBeingInStock([FromQuery] GetProductByBeingInStockRequest request)
        {
            return this.HandleRequest<GetProductByBeingInStockRequest, GetProductByBeingInStockResponse>(request);
        }

        [HttpGet]
        [Route("GetByCover/{cover}")]

        public Task<IActionResult> GetProductByAuthor([FromRoute] Product.Covers cover)
        {
            var request = new GetProductByCoverRequest()
            {
                Cover = cover
            };
            return this.HandleRequest<GetProductByCoverRequest, GetProductByCoverResponse>(request);
        }

        [HttpGet]
        [Route("GetByPublisher/{publisher}")]

        public Task<IActionResult> GetProductByPublisher([FromRoute] string publisher)
        {
            var request = new GetProductByPublisherRequest()
            {
                Publisher = publisher
            };
            return this.HandleRequest<GetProductByPublisherRequest, GetProductByPublisherResponse>(request);
        }

        [HttpGet]
        [Route("GetByCategory/{category}")]

        public Task<IActionResult> GetProductByCategory([FromRoute] Product.Categories category)
        {
            var request = new GetProductByCategoryRequest()
            {
                Category = category
            };
            return this.HandleRequest<GetProductByCategoryRequest, GetProductByCategoryResponse>(request);
        }

        [HttpGet]
        [Route("GetByPrice/{from:decimal}/{to:decimal}")]

        public Task<IActionResult> GetProductByPrice([FromRoute] decimal from, decimal to)
        {
            var request = new GetProductByPriceRequest()
            {
                PriceFrom = from,
                PriceTo = to
            };
            return this.HandleRequest<GetProductByPriceRequest, GetProductByPriceResponse>(request);
        }

        [HttpPost]
        [Route("AddProduct")]
        public Task<IActionResult> AddProduct([FromBody] AddProductRequest request)
        {
            return this.HandleRequest<AddProductRequest, AddProductResponse>(request);
        }           

        [HttpDelete]
        [Route("DeleteById/{productId}")]
        public Task<IActionResult> DeleteProduct([FromRoute] int productId)
        {
            var request = new DeleteProductByIdRequest()
            {
                Id = productId
            };
            return this.HandleRequest<DeleteProductByIdRequest, DeleteProductByIdResponse>(request);
        }

        [HttpPut]
        [Route("UpdateById/{productId}")]
        public Task<IActionResult> UpdateProduct( [FromRoute] int productId, [FromBody] UpdateProductRequest request)
        {
            productId = request.Id;
            return this.HandleRequest<UpdateProductRequest, UpdateProductResponse>(request);
        }
    }
}