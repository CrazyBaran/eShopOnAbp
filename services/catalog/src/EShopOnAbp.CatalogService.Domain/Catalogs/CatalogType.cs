using Volo.Abp.Domain.Entities.Auditing;

namespace EShopOnAbp.CatalogService.Catalogs
{
    public class CatalogType : FullAuditedEntity<int>
    {
        public string Type { get; set; }
    }
}