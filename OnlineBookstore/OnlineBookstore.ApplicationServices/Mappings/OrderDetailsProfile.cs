using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OnlineBookstore.ApplicationServices.API.Domain.Models;

namespace OnlineBookstore.ApplicationServices.Mappings
{
    public class OrderDetailsProfile : Profile
    {
        public OrderDetailsProfile()
        {
            CreateMap<DataAccess.Entities.OrderDetail, OrderDetail>()
                .ForMember(x => x.OrderId, y => y.MapFrom(z => z.OrderId))
                .ForMember(x => x.ProductId, y => y.MapFrom(z => z.ProductId))
                .ForMember(x => x.Amount, y => y.MapFrom(z => z.Amount))
                .ForMember(x => x.Price, y => y.MapFrom(z => z.Price));
        }

    }
}
