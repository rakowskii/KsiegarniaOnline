﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineBookstore.ApplicationServices.API.Domain.ReviewRequests;
using OnlineBookstore.DataAccess.Entities;
using OnlineBookstore.ApplicationServices.API.Domain.ProductRequests;
using OnlineBookstore.ApplicationServices.API.Domain.ProductResponses;
using OnlineBookstore.ApplicationServices.API.Domain.ReviewResponses;

namespace OnlineBookstore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReviewsController : ApiControllerBase
    {
        

        public ReviewsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("GetAll")]
        public Task<IActionResult> GetAllReviews([FromQuery] GetReviewsRequest request)
        {
            return this.HandleRequest<GetReviewsRequest, GetReviewsResponse>(request);
        }

        [HttpGet]
        [Route("GetByAddTime/{from}/{to}")]
        public Task<IActionResult> GetReviewByAddTime([FromRoute] DateTime from, DateTime to)
        {
            var request = new GetReviewByAddTimeRequest
            {
                From = from, 
                To = to
            };
            return this.HandleRequest<GetReviewByAddTimeRequest, GetReviewByAddTimeResponse>(request);
        }


        [HttpGet]
        [Route("GetByProductTitleAndCover/{title}/{cover}")]
        public Task<IActionResult> GetReviewByProductTitle([FromRoute] string title, Product.Covers cover)
        {
            var request = new GetReviewByProductTitleAndCoverRequest
            {
                Title = title,
                Cover = cover
            };
            return this.HandleRequest<GetReviewByProductTitleAndCoverRequest, GetReviewByProductTitleAndCoverResponse>(request);
        }


        [HttpGet]
        [Route("GetByUserLogin/{login}")]
        public Task<IActionResult> GetReviewByUserLogin([FromRoute] string login)
        {
            var request = new GetReviewByUserLoginRequest
            {
                Login = login
            };
            return this.HandleRequest<GetReviewByUserLoginRequest, GetReviewByUserLoginResponse>(request);
        }

        [HttpPost]
        [Route("AddReview")]
        public Task<IActionResult> AddReview([FromBody] AddReviewRequest request)
        {

            return this.HandleRequest<AddReviewRequest, AddReviewResponse>(request);
        }

        [HttpPut]
        [Route("UpdateById/{reviewId}")]
        public Task<IActionResult> UpdateReview([FromRoute] int reviewId ,[FromBody] UpdateReviewByIdRequest request)
        {
            reviewId = request.Id;
            return this.HandleRequest<UpdateReviewByIdRequest, UpdateReviewByIdResponse>(request);
        }

        [HttpDelete]
        [Route("DeleteById/{reviewId}")]
        public Task<IActionResult> DeleteReview([FromRoute] int reviewId)
        {
            var request = new DeleteReviewByIdRequest
            {
                ReviewId = reviewId
            };
            return this.HandleRequest<DeleteReviewByIdRequest, DeleteReviewByIdResponse>(request);
        }


    }
}

