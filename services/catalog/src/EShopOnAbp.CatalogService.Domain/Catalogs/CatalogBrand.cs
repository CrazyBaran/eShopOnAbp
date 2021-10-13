using Volo.Abp.Domain.Entities.Auditing;

namespace EShopOnAbp.CatalogService.Catalogs
{
    public class CatalogBrand : FullAuditedEntity<int>
    {
        public string Brand { get; set; }
    }
}