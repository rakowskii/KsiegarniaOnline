using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using OnlineBookstore.ApplicationServices.API.Domain.UserRequests;

namespace OnlineBookstore.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator mediator;


        public UsersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var request = new GetUserByIdRequest
            {
               UserId = id
            };

            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetByLogin/{login}")]
        public async Task<IActionResult> GetByLogin([FromRoute] string login)
        {
            var request = new GetUserByLoginRequest
            {
               Login = login
            };

            var response = await mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers([FromQuery] GetAllUsersRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }
          


        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] AddUserRequest request)
        {
            var response = await mediator.Send(request);
            return Ok(response);
        }

    }
}
            

