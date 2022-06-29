using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.ApplicationServices.API.Domain.UserRequests;
using OnlineBookstore.ApplicationServices.API.Domain.UserResponses;
using System.Threading.Tasks;

namespace OnlineBookstore.Controllers
{
    [Authorize]
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
        [Route("GetByLogin/{username}")]
        public Task<IActionResult> GetByLogin([FromRoute] string username)
        {
            var request = new GetUserByLoginRequest
            {
                Username = username
            };

            return this.HandleRequest<GetUserByLoginRequest, GetUserByLoginResponse>(request);
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public Task<IActionResult> GetAllUsers([FromQuery] GetAllUsersRequest request)
        {
            return this.HandleRequest<GetAllUsersRequest, GetAllUsersResponse>(request);
        }
         
        [AllowAnonymous]
        [HttpPost]
        [Route("AddUser")]
        public Task<IActionResult> AddUser([FromBody] AddUserRequest request)
        {
            return this.HandleRequest<AddUserRequest, AddUserResponse>(request);
        }
    }
}           