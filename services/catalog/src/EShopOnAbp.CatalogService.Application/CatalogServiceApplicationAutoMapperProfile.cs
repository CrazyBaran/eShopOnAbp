using AutoMapper;
using EShopOnAbp.CatalogService.Catalogs;

namespace EShopOnAbp.CatalogService
{
    public class CatalogServiceApplicationAutoMapperProfile : Profile
    {
        public CatalogServiceApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<CatalogItem, CatalogItemDto>();
            CreateMap<CatalogType, CatalogTypeDto>();
            CreateMap<CatalogBrand, CatalogBrandDto>();
        }
    }
}
