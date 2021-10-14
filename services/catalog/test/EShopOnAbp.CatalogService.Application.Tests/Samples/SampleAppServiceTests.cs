using System;
using Shouldly;
using System.Threading.Tasks;
using EShopOnAbp.CatalogService.Catalogs;
using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;
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
        private readonly ICurrentTenant _currentTenant;

        public SampleAppServiceTests()
        {
            _catalogAppService = GetRequiredService<ICatalogAppService>();
            _currentTenant = GetRequiredService<ICurrentTenant>();
        }

        [Fact]
        public async Task Initial_Data_Should_Contain_FakeItemA_Catalog_Item()
        {
            // Arrange
            var currentTenantId = _currentTenant.Id;
            _currentTenant.Change(Guid.Empty);
            
            // Act
            var result = await _catalogAppService.GetListAsync(new PagedAndSortedResultRequestDto());

            // Assert
            result.TotalCount.ShouldBeGreaterThan(0);
            result.Items.ShouldContain(c => c.Name == "fakeItemA");

            // Teardown
            _currentTenant.Change(currentTenantId);
        }
    }
}
