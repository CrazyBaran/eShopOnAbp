using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EShopOnAbp.CatalogService.Catalogs
{
    public class CatalogBrand : FullAuditedEntity<int>, IMultiTenant
    {
        public Guid? TenantId { get; }
        public string Brand { get; set; }
    }
}