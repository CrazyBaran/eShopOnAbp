using EShopOnAbp.CatalogService.Catalogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace EShopOnAbp.CatalogService.EntityConfigurations
{
    class CatalogTypeEntityTypeConfiguration
        : IEntityTypeConfiguration<CatalogType>
    {
        public void Configure(EntityTypeBuilder<CatalogType> builder)
        {
            builder.ToTable("CatalogType");

            builder.HasKey(ct => ct.Id);
            
            builder.Property(cb => cb.Type)
                .IsRequired()
                .HasMaxLength(100);
            
            builder.ConfigureByConvention();
        }
    }
}