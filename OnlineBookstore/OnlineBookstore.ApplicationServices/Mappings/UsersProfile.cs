using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineBookstore.ApplicationServices.API.Domain.Models;
using OnlineBookstore.ApplicationServices.API.Domain.UserRequests;

namespace OnlineBookstore.ApplicationServices.Mappings
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<DataAccess.Entities.User, User>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Username, y => y.MapFrom(z => z.Username))
                .ForMember(x => x.Firstname, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.Lastname, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.Role, y => y.MapFrom(z => z.Role));

            CreateMap<AddUserRequest, DataAccess.Entities.User>()
                .ForMember(x => x.Username, y => y.MapFrom(z => z.Username))
                .ForMember(x => x.Password, y => y.MapFrom(z => z.Password))
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.Firstname))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.Lastname))
                .ForMember(x => x.Role, y => y.MapFrom(z => z.Role));
        }
    }
}              