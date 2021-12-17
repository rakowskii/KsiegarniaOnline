using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using KsiegarniaOnline.ApplicationServices.API.Domain.Models;

namespace KsiegarniaOnline.ApplicationServices.Mappings
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<DataAccess.Entities.Order, Order>()
                .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId))
                .ForMember(x => x.OrderPlaced, y => y.MapFrom(z => z.OrderPlaced))
                .ForMember(x => x.OrderTotal, y => y.MapFrom(z => z.OrderTotal))
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.AddressLine1, y => y.MapFrom(z => z.AddressLine1))
                .ForMember(x => x.AddressLine2, y => y.MapFrom(z => z.AddressLine2))
                .ForMember(x => x.ZipCode, y => y.MapFrom(z => z.ZipCode))
                .ForMember(x => x.City, y => y.MapFrom(z => z.City))
                .ForMember(x => x.State, y => y.MapFrom(z => z.State))
                .ForMember(x => x.Country, y => y.MapFrom(z => z.Country))
                .ForMember(x => x.PhoneNumber, y => y.MapFrom(z => z.PhoneNumber))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Email));

        }

    }
}
