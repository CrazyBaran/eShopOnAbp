using Volo.Abp.Application.Dtos;

namespace EShopOnAbp.CatalogService.Catalogs
{
    public class CatalogTypeDto : AuditedEntityDto<int>
    {
        public string Type { get; set; }
    }
}