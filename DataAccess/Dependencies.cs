using Infrastructure.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class Dependencies
    {
        public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            var useOnlyInMemoryDatabase = false;
            if (configuration["UseOnlyInMemoryDatabase"] != null)
            {
                useOnlyInMemoryDatabase = bool.Parse(configuration["UseOnlyInMemoryDatabase"]);
            }

            if (useOnlyInMemoryDatabase)
            {
                //services.AddDbContext<LegoContext>(c =>
                //   c.UseInMemoryDatabase("LegoContext"));

                //services.AddDbContext<AppIdentityDbContext>(options =>
                //    options.UseInMemoryDatabase("Identity"));
            }
            else
            {
                // use real database
                // Requires LocalDB which can be installed with SQL Server Express 2016
                // https://www.microsoft.com/en-us/download/details.aspx?id=54284
                services.AddDbContext<LegoContext>(c =>
                    c.UseSqlServer(configuration.GetConnectionString("LegoDBCnn")));

                //// Add Identity DbContext
                //services.AddDbContext<AppIdentityDbContext>(options =>
                //    options.UseSqlServer(configuration.GetConnectionString("IdentityConnection")));
            }
        }
    }
}
