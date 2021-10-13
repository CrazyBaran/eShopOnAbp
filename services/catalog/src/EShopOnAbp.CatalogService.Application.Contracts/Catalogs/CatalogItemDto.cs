using System;
using Volo.Abp.Application.Dtos;

namespace EShopOnAbp.CatalogService.Catalogs
{
    public class CatalogItemDto : AuditedEntityDto<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string PictureFileName { get; set; }

        public string PictureUri { get; set; }
        
        public CatalogTypeDto CatalogType { get; set; }
            
        public  CatalogBrandDto CatalogBrand { get; set; }
    }
}