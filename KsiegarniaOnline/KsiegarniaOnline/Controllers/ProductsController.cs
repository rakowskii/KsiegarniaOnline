using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KsiegarniaOnline.ApplicationServices.API.Domain.ProductRequests;
using KsiegarniaOnline.ApplicationServices.API.Domain.ProductResponses;
using MediatR;
using KsiegarniaOnline.DataAccess.Entities;


namespace KsiegarniaOnline.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllProducts([FromQuery] GetProductsRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetById/{id}")]

        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            var request = new GetProductByIdRequest()
            {
                ProductsId = id
            };

            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetByTitle/{title}")]

        public async Task<IActionResult> GetProductByTitle([FromRoute] string title)
        {
            var request = new GetProductByTitleRequest()
            {
                ProductsTitle = title
            };

            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetByAuthor/{author}")]

        public async Task<IActionResult> GetProductByAuthor([FromRoute] string author)
        {
            var request = new GetProductByAuthorRequest()
            {
                ProductsAuthor = author
            };
            var response = await mediator.Send(request);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetBySeries/{series}")]

        public async Task<IActionResult> GetProductBySeries([FromRoute] string series)
        {
            var request = new GetProductBySeriesRequest()
            {
                ProductsSeries = series
            };
            var response = await mediator.Send(request);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetByType/{type}")]

        public async Task<IActionResult> GetProductByType([FromRoute] Product.Types type)
        {
            var request = new GetProductByTypeRequest()
            {
                Type = type
            };
            var response = await mediator.Send(request);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetByBeingBestseller")]

        public async Task<IActionResult> GetProductByBeingBestseller([FromQuery] GetProductByBeingBestsellerRequest request)
        {
           
            var response = await mediator.Send(request);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetByBeingInStock")]

        public async Task<IActionResult> GetProductByBeingInStock([FromQuery] GetProductByBeingInStockRequest request)
        {
            
            var response = await mediator.Send(request);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetByCover/{cover}")]

        public async Task<IActionResult> GetProductByAuthor([FromRoute] Product.Covers cover)
        {
            var request = new GetProductByCoverRequest()
            {
                Cover = cover
            };
            var response = await mediator.Send(request);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetByPublisher/{publisher}")]

        public async Task<IActionResult> GetProductByPublisher([FromRoute] string publisher)
        {
            var request = new GetProductByPublisherRequest()
            {
                Publisher = publisher
            };
            var response = await mediator.Send(request);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetByCategory/{category}")]

        public async Task<IActionResult> GetProductByCategory([FromRoute] Product.Categories category)
        {
            var request = new GetProductByCategoryRequest()
            {
                Category = category
            };
            var response = await mediator.Send(request);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetByPrice/{from:decimal}/{to:decimal}")]

        public async Task<IActionResult> GetProductByPrice([FromRoute] decimal from, decimal to)
        {
            var request = new GetProductByPriceRequest()
            {
                PriceFrom = from,
                PriceTo = to
            };
            var response = await mediator.Send(request);

            return Ok(response);
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] AddProductRequest request)
        {
            var product = await mediator.Send(request);
            return Ok(product);

        }

        [HttpDelete]
        [Route("DeleteById/{productId}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int productId)
        {
            var request = new DeleteProductByIdRequest()
            {
                Id = productId
            };
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        [Route("UpdateById/{productId}")]
        public async Task<IActionResult> UpdateProduct( [FromRoute] int productId, [FromBody] UpdateProductRequest request)
        {
            productId = request.Id;
            var response = await mediator.Send(request);
            return Ok(response);
        }

    }
}

















