using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EShopOnAbp.CatalogService.Catalogs
{
    public interface ICatalogAppService: ICrudAppService<
        CatalogItemDto, 
        int, 
        PagedAndSortedResultRequestDto, 
        CreateOrUpdateCatalogItemDto>
    {
        
    }
}