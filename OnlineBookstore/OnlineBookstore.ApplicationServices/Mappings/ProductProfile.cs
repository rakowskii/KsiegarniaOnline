using AutoMapper;
using OnlineBookstore.ApplicationServices.API.Domain.ProductRequests;
using OnlineBookstore.ApplicationServices.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookstore.ApplicationServices.Mappings
{
   public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<DataAccess.Entities.Product, Product>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Title, y => y.MapFrom(z => z.Title))
                .ForMember(x => x.Author, y => y.MapFrom(z => z.Author))
                .ForMember(x => x.Publisher, y => y.MapFrom(z => z.Publisher))
                .ForMember(x => x.Year, y => y.MapFrom(z => z.Year))
                .ForMember(x => x.Pages, y => y.MapFrom(z => z.Pages))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.Price, y => y.MapFrom(z => z.Price))
                .ForMember(x => x.ImageUrl, y => y.MapFrom(z => z.ImageUrl))
                .ForMember(x => x.IsBestseller, y => y.MapFrom(z => z.IsBestseller))
                .ForMember(x => x.InStock, y => y.MapFrom(z => z.InStock))
                .ForMember(x => x.Series, y => y.MapFrom(z => z.Series))
                .ForMember(x => x.Type, y => y.MapFrom(z => z.Type))
                .ForMember(x => x.Category, y => y.MapFrom(z => z.Category))
                .ForMember(x => x.Cover, y => y.MapFrom(z => z.Cover))
                .ForMember(x => x.Reviews, y => y.MapFrom(z => z.Reviews));

            CreateMap<AddProductRequest, DataAccess.Entities.Product>()
                .ForMember(x => x.Title, y => y.MapFrom(z => z.Title))
                .ForMember(x => x.Author, y => y.MapFrom(z => z.Author))
                .ForMember(x => x.Publisher, y => y.MapFrom(z => z.Publisher))
                .ForMember(x => x.Year, y => y.MapFrom(z => z.Year))
                .ForMember(x => x.Pages, y => y.MapFrom(z => z.Pages))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.Price, y => y.MapFrom(z => z.Price))
                .ForMember(x => x.ImageUrl, y => y.MapFrom(z => z.ImageUrl))
                .ForMember(x => x.IsBestseller, y => y.MapFrom(z => z.IsBestseller))
                .ForMember(x => x.InStock, y => y.MapFrom(z => z.InStock))
                .ForMember(x => x.Series, y => y.MapFrom(z => z.Series))
                .ForMember(x => x.Type, y => y.MapFrom(z => z.Type))
                .ForMember(x => x.Category, y => y.MapFrom(z => z.Category))
                .ForMember(x => x.Cover, y => y.MapFrom(z => z.Cover));

            CreateMap<DeleteProductByIdRequest, DataAccess.Entities.Product>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));
               
            CreateMap<UpdateProductRequest, DataAccess.Entities.Product>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Title, y => y.MapFrom(z => z.Title))
                .ForMember(x => x.Author, y => y.MapFrom(z => z.Author))
                .ForMember(x => x.Publisher, y => y.MapFrom(z => z.Publisher))
                .ForMember(x => x.Year, y => y.MapFrom(z => z.Year))
                .ForMember(x => x.Pages, y => y.MapFrom(z => z.Pages))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.Price, y => y.MapFrom(z => z.Price))
                .ForMember(x => x.ImageUrl, y => y.MapFrom(z => z.ImageUrl))
                .ForMember(x => x.IsBestseller, y => y.MapFrom(z => z.IsBestseller))
                .ForMember(x => x.InStock, y => y.MapFrom(z => z.InStock))
                .ForMember(x => x.Series, y => y.MapFrom(z => z.Series))
                .ForMember(x => x.Type, y => y.MapFrom(z => z.Type))
                .ForMember(x => x.Category, y => y.MapFrom(z => z.Category))
                .ForMember(x => x.Cover, y => y.MapFrom(z => z.Cover));
        }
    }
}









