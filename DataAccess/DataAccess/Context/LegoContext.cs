using Infrastructure.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess.Context
{
    public class LegoContext : DbContext
    {
        public LegoContext(DbContextOptions<LegoContext> options) : base(options)
        {

        }

        public DbSet<LegoProduct> LegoProducts { get; set; }
        public DbSet<LegoProductStatus> LegoProductStatuses { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<LegoProductTheme> LegoProductThemes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Theme>().Property(t => t.ThemeID).ValueGeneratedOnAdd();
            builder.Entity<LegoProductStatus>().Property(stt => stt.ProductStatusID).ValueGeneratedOnAdd();

            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
