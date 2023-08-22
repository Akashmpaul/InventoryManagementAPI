using AutoMapper;
using InventoryManagement.Data.Models;
using InventoryManagement.DTOs;

namespace InventoryManagement.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<ProductCategory, ProductCategoryDto>();
            CreateMap<ProductCategoryDto, ProductCategory>();
            CreateMap<ProductStatus, ProductStatusDto>();
            CreateMap<ProductStatusDto, ProductStatus>();
            CreateMap<Mechanism, MechanismDto>();
            CreateMap<MechanismDto, Mechanism>();
            CreateMap<NozzleFlow, NozzleFlowDto>();
            CreateMap<ProductCategoryDto, NozzleFlow>();

        }
    }

}
