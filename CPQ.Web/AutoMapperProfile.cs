using AutoMapper;
using CPQ.Domain;
using CPQ.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPQ.Web
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductViewModel>();
        }
    }
}