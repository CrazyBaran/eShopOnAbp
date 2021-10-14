namespace EShopOnAbp.CatalogService.Events
{
    public class ProductPriceChangedIntegrationEvent
    {
        public int CatalogItemId { get; }
        public decimal NewPrice { get; }
        public decimal OldPrice { get; }
        
        public ProductPriceChangedIntegrationEvent(int catalogItemId, decimal newPrice, decimal oldPrice)
        {
            CatalogItemId = catalogItemId;
            NewPrice = newPrice;
            OldPrice = oldPrice;
        }
        
    }
}