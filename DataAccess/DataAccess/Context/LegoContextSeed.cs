using Infrastructure.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess.Context
{
    public class LegoContextSeed
    {
        public static async Task SeedAsync(LegoContext context)
        {

        }

        static IEnumerable<Theme> SeedThemes()
        {
            return new List<Theme>()
            {
                new Theme
                {
                   ThemeID = 1,
                   ThemeName = "Test theme name"
                },
            };
        }
    }
}
