using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineBookstore.ApplicationServices.API.Domain.ReviewRequests;
using OnlineBookstore.DataAccess.Entities;

namespace OnlineBookstore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ReviewsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllReviews([FromQuery] GetReviewsRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetByAddTime/{from}/{to}")]
        public async Task<IActionResult> GetReviewByAddTime([FromRoute] DateTime from, DateTime to)
        {
            var request = new GetReviewByAddTimeRequest
            {
                From = from, 
                To = to
            };
            var response = await mediator.Send(request);
            return Ok(response);
        }


        [HttpGet]
        [Route("GetByProductTitleAndCover/{title}/{cover}")]
        public async Task<IActionResult> GetReviewByProductTitle([FromRoute] string title, Product.Covers cover)
        {
            var request = new GetReviewByProductTitleAndCoverRequest
            {
                Title = title,
                Cover = cover
            };
            var response = await mediator.Send(request);
            return Ok(response);
        }


        [HttpGet]
        [Route("GetByUserLogin/{login}")]
        public async Task<IActionResult> GetReviewByUserLogin([FromRoute] string login)
        {
            var request = new GetReviewByUserLoginRequest
            {
                Login = login
            };
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        [Route("AddReview")]
        public async Task<IActionResult> AddReview([FromBody] AddReviewRequest request)
        {
            
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        [Route("UpdateById/{reviewId}")]
        public async Task<IActionResult> UpdateReview([FromRoute] int reviewId ,[FromBody] UpdateReviewByIdRequest request)
        {
            reviewId = request.Id;
            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteById/{reviewId}")]
        public async Task<IActionResult> DeleteReview([FromRoute] int reviewId)
        {
            var request = new DeleteReviewByIdRequest
            {
                ReviewId = reviewId
            };
            var response = await mediator.Send(request);
            return Ok(response);
        }


    }
}

