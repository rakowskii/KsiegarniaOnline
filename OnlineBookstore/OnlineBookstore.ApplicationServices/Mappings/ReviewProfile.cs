using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineBookstore.ApplicationServices.API.Domain.Models;
using OnlineBookstore.ApplicationServices.API.Domain.ReviewRequests;
using OnlineBookstore.ApplicationServices.API.Domain.ProductRequests;

namespace OnlineBookstore.ApplicationServices.Mappings
{
    class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<DataAccess.Entities.Review, Review>()
                .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId))
                .ForMember(x => x.AddDate, y => y.MapFrom(z => z.AddDate))
                .ForMember(x => x.Reviews, y => y.MapFrom(z => z.Reviews));

            CreateMap<AddReviewRequest, DataAccess.Entities.Review>()
                .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId))
                .ForMember(x => x.ProductId, y => y.MapFrom(z => z.ProductId))
                .ForMember(x => x.AddDate, y => y.MapFrom(z => z.AddDate))
                .ForMember(x => x.Reviews, y => y.MapFrom(z => z.Reviews));

            CreateMap<DeleteReviewByIdRequest, DataAccess.Entities.Review>()
               .ForMember(x => x.Id, y => y.MapFrom(z => z.ReviewId));

            CreateMap<UpdateReviewByIdRequest, DataAccess.Entities.Review>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId))
                .ForMember(x => x.ProductId, y => y.MapFrom(z => z.ProductId))
                .ForMember(x => x.Reviews, y => y.MapFrom(z => z.Reviews));
        }
    }
}
                
                
                

               




