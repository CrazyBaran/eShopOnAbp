using EShopOnAbp.CatalogService.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EventBus.Distributed;

namespace EShopOnAbp.CatalogService.Catalogs
{
    [Authorize( CatalogServicePermissions.CatalogItems.Default)]
    public class CatalogAppService : 
        CrudAppService<
            CatalogItem, 
            CatalogItemDto, 
            int, 
            PagedAndSortedResultRequestDto, 
            CreateOrUpdateCatalogItemDto>, 
        ICatalogAppService
    {
        public CatalogAppService(IRepository<CatalogItem, int> repository) : base(repository)
        {
            GetPolicyName = CatalogServicePermissions.CatalogItems.Default;
            GetListPolicyName = CatalogServicePermissions.CatalogItems.Default;
            CreatePolicyName = CatalogServicePermissions.CatalogItems.Create;
            UpdatePolicyName = CatalogServicePermissions.CatalogItems.Edit;
            DeletePolicyName = CatalogServicePermissions.CatalogItems.Delete;
        }
    }
}