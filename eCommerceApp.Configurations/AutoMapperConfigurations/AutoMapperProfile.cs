using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using eCommerceApp.Models;
using eCommerceApp.Models.ApiViewModels;

namespace eCommerceApp.Configurations.AutoMapperConfigurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductSearchCriteriaVm, Product>();
            CreateMap<Product, ProductSearchCriteriaVm>();

            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();
        }
    }
}