﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using OnlineBookstore.ApplicationServices.API.Domain.UserRequests;
using OnlineBookstore.ApplicationServices.API.Domain.ReviewRequests;
using OnlineBookstore.ApplicationServices.API.Domain.ReviewResponses;
using OnlineBookstore.ApplicationServices.API.Domain.UserResponses;

namespace OnlineBookstore.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UsersController : ApiControllerBase
    {
        


        public UsersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public Task<IActionResult> GetById([FromRoute] int id)
        {
            var request = new GetUserByIdRequest
            {
               UserId = id
            };

            return this.HandleRequest<GetUserByIdRequest, GetUserByIdResponse>(request);
        }

        [HttpGet]
        [Route("GetByLogin/{login}")]
        public Task<IActionResult> GetByLogin([FromRoute] string login)
        {
            var request = new GetUserByLoginRequest
            {
               Login = login
            };

            return this.HandleRequest<GetUserByLoginRequest, GetUserByLoginResponse>(request);
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public Task<IActionResult> GetAllUsers([FromQuery] GetAllUsersRequest request)
        {
            return this.HandleRequest<GetAllUsersRequest, GetAllUsersResponse>(request);
        }
          


        [HttpPost]
        [Route("AddUser")]
        public Task<IActionResult> AddUser([FromBody] AddUserRequest request)
        {
            return this.HandleRequest<AddUserRequest, AddUserResponse>(request);
        }

    }
}
            

