using EShopOnAbp.CatalogService.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace EShopOnAbp.CatalogService.Catalogs
{
    [Authorize( CatalogServicePermissions.Catalogs.Default)]
    public class CatalogAppService : 
        CrudAppService<
            CatalogItem, 
            CatalogItemDto, 
            int, 
            PagedAndSortedResultRequestDto>, 
        ICatalogAppService
    {
        public CatalogAppService(IRepository<CatalogItem, int> repository) : base(repository)
        {
            GetPolicyName = CatalogServicePermissions.Catalogs.Default;
        }
    }
}