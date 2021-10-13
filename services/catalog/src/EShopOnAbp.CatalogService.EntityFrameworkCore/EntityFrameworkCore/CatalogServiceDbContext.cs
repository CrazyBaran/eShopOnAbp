using EShopOnAbp.CatalogService.Catalogs;
using EShopOnAbp.CatalogService.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace EShopOnAbp.CatalogService.EntityFrameworkCore
{
    [ConnectionStringName(CatalogServiceDbProperties.ConnectionStringName)]
    public class CatalogServiceDbContext :
        AbpDbContext<CatalogServiceDbContext>
    {
        public DbSet<CatalogItem> CatalogItems { get; set; }
        public DbSet<CatalogBrand> CatalogBrands { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; }
        
        public CatalogServiceDbContext(DbContextOptions<CatalogServiceDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.ApplyConfiguration(new CatalogBrandEntityTypeConfiguration());
            builder.ApplyConfiguration(new CatalogTypeEntityTypeConfiguration());
            builder.ApplyConfiguration(new CatalogItemEntityTypeConfiguration());
            
            /* Include modules to your migration db context */

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(CatalogServiceConsts.DbTablePrefix + "YourEntities", CatalogServiceConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}
