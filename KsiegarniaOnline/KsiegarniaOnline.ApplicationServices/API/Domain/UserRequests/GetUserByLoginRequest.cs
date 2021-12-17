using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KsiegarniaOnline.ApplicationServices.API.Domain.UserResponses;
using MediatR;

namespace KsiegarniaOnline.ApplicationServices.API.Domain.UserRequests
{
    public class GetUserByLoginRequest : IRequest<GetUserByLoginResponse>
    {
        public string Login { get; set; }
    }
}
