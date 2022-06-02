using Infrastructure.DataAccess.Entities;

namespace Infrastructure.DataAccess.Context
{
    public class LegoContextSeed
    {
        public static async Task SeedAsync(LegoContext context)
        {
            await context.Themes.AddRangeAsync(SeedThemes());

            await context.LegoProductStatuses.AddRangeAsync(SeedLegoProductStatuses());

            await context.LegoProducts.AddRangeAsync(SeedLegoProducts());

            await context.LegoProductThemes.AddRangeAsync(SeedLegoProductThemes());

            await context.SaveChangesAsync();
        }

        static IEnumerable<Theme> SeedThemes()
        {
            return new List<Theme>()
            {
                new Theme
                {
                   ThemeID = 1,
                   ThemeName = "Car"
                },
                new Theme
                {
                    ThemeID = 2,
                   ThemeName = "Space"
                },
                new Theme
                {
                    ThemeID = 3,
                   ThemeName = "City"
                },
                new Theme
                {
                    ThemeID = 4,
                   ThemeName = "Friend"
                }
            };
        }

        static IEnumerable<LegoProductStatus> SeedLegoProductStatuses()
        {
            return new List<LegoProductStatus>()
            {
                new LegoProductStatus
                {
                   ProductStatusID = 1,
                   ProductStatusName = "In stock"
                },
                new LegoProductStatus
                {
                   ProductStatusID = 1,
                   ProductStatusName = "Sold out"
                },
            };
        }

        static IEnumerable<LegoProduct> SeedLegoProducts()
        {
            return new List<LegoProduct>()
            {
                new LegoProduct
                {
                   ProductID = "dubai",
                   ProductName = "Dubai City",
                   ProductDisplayName = "Dubai City",
                   ProductStatusID = 1,
                   CurrencyCode = "USD",
                   Price = 123,
                },
                new LegoProduct
                {
                   ProductID = "hanoi",
                   ProductName = "Hanoi City",
                   ProductDisplayName = "Hanoi City",
                   ProductStatusID = 1,
                   CurrencyCode = "VND",
                   Price = 250000,
                },
                new LegoProduct
                {
                   ProductID = "starwar",
                   ProductName = "Starwar Ship",
                   ProductDisplayName = "Starwar Ship",
                   ProductStatusID = 1,
                   CurrencyCode = "VND",
                   Price = 510000,
                }
            };
        }

        static IEnumerable<LegoProductTheme> SeedLegoProductThemes()
        {
            return new List<LegoProductTheme>()
            {
                new LegoProductTheme
                {
                   ThemeID = 1,
                   ProductID = "dubai"
                },
                new LegoProductTheme
                {
                   ThemeID = 3,
                   ProductID = "dubai"
                },
                new LegoProductTheme
                {
                   ThemeID = 3,
                   ProductID = "hanoi"
                },
                new LegoProductTheme
                {
                   ThemeID = 2,
                   ProductID = "starwar"
                },
            };
        }
    }
}
