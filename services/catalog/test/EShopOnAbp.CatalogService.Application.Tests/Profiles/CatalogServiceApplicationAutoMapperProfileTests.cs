using AutoMapper;
using Xunit;

namespace EShopOnAbp.CatalogService.Profiles
{
    public class CatalogServiceApplicationAutoMapperProfileTests
    {
        [Fact]
        public void CatalogServiceApplicationAutoMapperProfile_Should_Be_Valid()
        {
            // Arrange
            var configuration =
                new MapperConfiguration(cfg => cfg.AddProfile<CatalogServiceApplicationAutoMapperProfile>());
            
            //Act & Assert
            configuration.AssertConfigurationIsValid();
        }
    }
}