using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KsiegarniaOnline.ApplicationServices.API.Domain.ReviewRequests;

namespace KsiegarniaOnline.Controllers
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
        [Route("GetByProductTitle/{title}")]
        public async Task<IActionResult> GetReviewByProductTitle([FromRoute] string title)
        {
            var request = new GetReviewByProductTitleRequest
            {
                Title = title
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
        [Route("")]
        public async Task<IActionResult> AddReview([FromBody] AddReviewRequest request)
        {
            
            var response = await mediator.Send(request);
            return Ok(response);
        }


    }
}

