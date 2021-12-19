using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineBookstore.ApplicationServices.API.Domain.UserResponses;
using MediatR;

namespace OnlineBookstore.ApplicationServices.API.Domain.UserRequests
{
    public class GetAllUsersRequest : IRequest<GetAllUsersResponse>
    {

    }
}
