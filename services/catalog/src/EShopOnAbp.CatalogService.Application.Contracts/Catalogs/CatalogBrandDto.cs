using Volo.Abp.Application.Dtos;

namespace EShopOnAbp.CatalogService.Catalogs
{
    public class CatalogBrandDto: AuditedEntityDto<int>
    {
        public string Brand { get; set; }
    }
}