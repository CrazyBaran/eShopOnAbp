using EShopOnAbp.CatalogService.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace EShopOnAbp.CatalogService.Catalogs
{
    [Authorize( CatalogServicePermissions.CatalogItems.Default)]
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
            GetPolicyName = CatalogServicePermissions.CatalogItems.Default;
            GetListPolicyName = CatalogServicePermissions.CatalogItems.Default;
            CreatePolicyName = CatalogServicePermissions.CatalogItems.Create;
            UpdatePolicyName = CatalogServicePermissions.CatalogItems.Edit;
            DeletePolicyName = CatalogServicePermissions.CatalogItems.Delete;
        }
    }
}