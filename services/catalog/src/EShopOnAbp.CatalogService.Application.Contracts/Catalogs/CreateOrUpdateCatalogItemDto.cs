namespace EShopOnAbp.CatalogService.Catalogs
{
    public class CreateOrUpdateCatalogItemDto
    {
        public int? Id { get; set; }
        public int CatalogBrandId { get; set; }
        public int CatalogTypeId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string PictureFileName { get; set; }
        public decimal Price { get; set; }
    }
}