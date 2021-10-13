using Shouldly;
using System.Threading.Tasks;
using EShopOnAbp.CatalogService.Catalogs;
using Volo.Abp.Application.Dtos;
using Xunit;

namespace EShopOnAbp.CatalogService.Samples
{
    /* This is just an example test class.
     * Normally, you don't test code of the modules you are using
     * (like IIdentityUserAppService here).
     * Only test your own application services.
     */
    public class SampleAppServiceTests : CatalogServiceApplicationTestBase
    {
        private readonly ICatalogAppService _catalogAppService;

        public SampleAppServiceTests()
        {
            _catalogAppService = GetRequiredService<ICatalogAppService>();
        }

        [Fact]
        public async Task Initial_Data_Should_Contain_FakeItemA_Catalog_Item()
        {
            //Act
            var result = await _catalogAppService.GetListAsync(new PagedAndSortedResultRequestDto());

            //Assert
            result.TotalCount.ShouldBeGreaterThan(0);
            result.Items.ShouldContain(c => c.Name == "fakeItemA");
        }
    }
}
