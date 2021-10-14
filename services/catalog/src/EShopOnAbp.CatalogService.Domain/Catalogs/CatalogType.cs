using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace EShopOnAbp.CatalogService.Catalogs
{
    public class CatalogType : FullAuditedEntity<int>, IMultiTenant
    {
        public Guid? TenantId { get; }
        public string Type { get; set; }
    }
}