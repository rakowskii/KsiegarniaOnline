using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KsiegarniaOnline.ApplicationServices.API.Domain.UserResponses;
using KsiegarniaOnline.DataAccess.Entities;
using MediatR;

namespace KsiegarniaOnline.ApplicationServices.API.Domain.UserRequests
{
    public class AddUserRequest : IRequest<AddUserResponse>
    {
        
        public string Login { get; set; }
        public string Password { get; set; }
        public Role Roles { get; set; }
    }
}
