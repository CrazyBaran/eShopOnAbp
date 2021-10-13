using EShopOnAbp.CatalogService.Catalogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace EShopOnAbp.CatalogService.EntityConfigurations
{
    class CatalogBrandEntityTypeConfiguration
        : IEntityTypeConfiguration<CatalogBrand>
    {
        public void Configure(EntityTypeBuilder<CatalogBrand> builder)
        {
            builder.ToTable("CatalogBrand");

            builder.HasKey(cb => cb.Id);

            builder.Property(cb => cb.Brand)
                .IsRequired()
                .HasMaxLength(100);
            
            builder.ConfigureByConvention();
        }
    }
}