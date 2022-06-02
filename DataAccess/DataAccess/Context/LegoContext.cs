using Infrastructure.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.DataAccess.Context
{
    public class LegoContext : DbContext
    {
        public LegoContext(DbContextOptions<LegoContext> options)
        : base(options)
        {
        }

        public DbSet<LegoProduct> LegoProducts { get; set; }
        public DbSet<LegoProductStatus> LegoProductStatuses { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<LegoProductTheme> LegoProductThemes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Theme>().Property(t => t.ThemeID).ValueGeneratedOnAdd();
            builder.Entity<LegoProductStatus>().Property(stt => stt.ProductStatusID).ValueGeneratedOnAdd();

            builder
            .Entity<LegoProduct>()
            .HasMany(p => p.Themes)
            .WithMany(p => p.Products)
            .UsingEntity<LegoProductTheme>(
                j => j
                    .HasOne(pt => pt.Theme)
                    .WithMany(p => p.ProductThemes)
                    .HasPrincipalKey(pt => pt.ThemeID),
                j => j
                    .HasOne(pt => pt.Product)
                    .WithMany(t => t.ProductThemes)
                    .HasPrincipalKey(pt => pt.ProductID)
            );


            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
