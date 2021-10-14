using System;
using System.Threading.Tasks;
using EShopOnAbp.CatalogService.Catalogs;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace EShopOnAbp.CatalogService
{
    public class CatalogServiceTestDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<CatalogItem, int> _catalogRepository;

        public CatalogServiceTestDataSeedContributor(IRepository<CatalogItem, int> catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }
        public async Task SeedAsync(DataSeedContext context)
        {
            var catalogType = new CatalogType()
            {
                Type = "fakeTypeA"
            };

            var catalogBrand = new CatalogBrand()
            {
                Brand = "fakeBrandA"
            };
            await _catalogRepository.InsertManyAsync(new[]
            {
                new CatalogItem(tenantId: Guid.Empty, price: 0.001m)
                {
                    Name = "fakeItemA",
                    CatalogType = catalogType,
                    CatalogBrand = catalogBrand,
                    PictureFileName = "fakeItemA.png"
                },
                new CatalogItem(tenantId: Guid.Empty, price: 0.001m)
                {
                    Name = "fakeItemB",
                    CatalogType = catalogType,
                    CatalogBrand = catalogBrand,
                    PictureFileName = "fakeItemB.png"
                },
                new CatalogItem(tenantId: Guid.Empty, price: 0.001m)
                {
                    Name = "fakeItemC",
                    CatalogType = catalogType,
                    CatalogBrand = catalogBrand,
                    PictureFileName = "fakeItemC.png"
                },
                new CatalogItem(tenantId: Guid.Empty, price: 0.001m)
                {
                    Name = "fakeItemD",
                    CatalogType = catalogType,
                    CatalogBrand = catalogBrand,
                    PictureFileName = "fakeItemD.png"
                },
                new CatalogItem(tenantId: Guid.Empty, price: 0.001m)
                {
                    Name = "fakeItemE",
                    CatalogType = catalogType,
                    CatalogBrand = catalogBrand,
                    PictureFileName = "fakeItemE.png"
                },
                new CatalogItem(tenantId: Guid.Empty, price: 0.001m)
                {
                    Name = "fakeItemF",
                    CatalogType = catalogType,
                    CatalogBrand = catalogBrand,
                    PictureFileName = "fakeItemF.png"
                }
            });
        }
    }
}