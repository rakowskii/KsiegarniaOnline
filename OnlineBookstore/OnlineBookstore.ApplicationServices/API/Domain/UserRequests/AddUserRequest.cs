using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineBookstore.ApplicationServices.API.Domain.UserResponses;
using OnlineBookstore.DataAccess.Entities;
using MediatR;

namespace OnlineBookstore.ApplicationServices.API.Domain.UserRequests
{
    public class AddUserRequest : IRequest<AddUserResponse>
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Role Roles { get; set; }
    }
}
        
