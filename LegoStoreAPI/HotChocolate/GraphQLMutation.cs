using Infrastructure.DataAccess.Context;
using Infrastructure.DataAccess.Entities;
using LegoStoreAPI.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace LegoStoreAPI.HotChocolate;

public class GraphQLMutation
{
    #region Theme
    [UseMutationConvention]
    public async Task<Theme> AddTheme([Service] LegoContext dbContext, string themeName)
    {
        var theme = new Theme
        {
            ThemeName = themeName
        };

        await dbContext.AddAsync(theme);
        await dbContext.SaveChangesAsync();

        return theme;
    }

    [UseMutationConvention]
    [Error(typeof(NotFoundException))]
    public async Task<Theme> UpdateTheme([Service] LegoContext dbContext, int themeId, string themeName)
    {
        var theme = await dbContext.FindAsync<Theme>(themeId);

        if(theme == null)
        {
            throw new NotFoundException(themeId.ToString(), $"Theme {themeId} is not existed");
        }

        theme.ThemeName = themeName;

        dbContext.Update(theme);
        await dbContext.SaveChangesAsync();

        return theme;
    }

    [UseMutationConvention]
    [Error(typeof(NotFoundException))]
    public async Task<Theme> DeleteTheme([Service] LegoContext dbContext, int themeId)
    {
        var theme = await dbContext.FindAsync<Theme>(themeId);

        if (theme == null)
        {
            throw new NotFoundException(themeId.ToString(), $"Theme {themeId} is not existed");
        }

        dbContext.Remove(theme);
        await dbContext.SaveChangesAsync();

        return theme;
    }
    #endregion

    #region LegoProductStatus
    [UseMutationConvention]
    public async Task<LegoProductStatus> AddLegoProductStatus([Service] LegoContext dbContext, string productStatusName)
    {
        var legoProductStatus = new LegoProductStatus
        {
            ProductStatusName = productStatusName
        };

        await dbContext.AddAsync(legoProductStatus);
        await dbContext.SaveChangesAsync();

        return legoProductStatus;
    }

    [UseMutationConvention]
    [Error(typeof(NotFoundException))]
    public async Task<LegoProductStatus> UpdateLegoProductStatus([Service] LegoContext dbContext, int productStatusId, string productStatusName)
    {
        var legoProductStatus = await dbContext.FindAsync<LegoProductStatus>(productStatusId);

        if (legoProductStatus == null)
        {
            throw new NotFoundException(productStatusId.ToString(), $"LegoProductStatus {productStatusId} is not existed");
        }

        legoProductStatus.ProductStatusName = productStatusName;

        dbContext.Update(legoProductStatus);
        await dbContext.SaveChangesAsync();

        return legoProductStatus;
    }

    [UseMutationConvention]
    [Error(typeof(NotFoundException))]
    public async Task<LegoProductStatus> DeleteLegoProductStatus([Service] LegoContext dbContext, int productStatusId)
    {
        var legoProductStatus = await dbContext.FindAsync<LegoProductStatus>(productStatusId);

        if (legoProductStatus == null)
        {
            throw new NotFoundException(productStatusId.ToString(), $"LegoProductStatus {productStatusId} is not existed");
        }

        dbContext.Remove(legoProductStatus);
        await dbContext.SaveChangesAsync();

        return legoProductStatus;
    }
    #endregion

    #region LegoProduct
    [UseMutationConvention]
    public async Task<LegoProduct> AddLegoProduct([Service] LegoContext dbContext, string productID, string productName, string productDisplayName, decimal price, string currencyCode
        , int productStatusID)
    {
        var legoProduct = new LegoProduct
        {
            ProductID = productID,
            ProductName = productName,
            ProductDisplayName = productDisplayName,
            Price = price,
            CurrencyCode = currencyCode,
            ProductStatusID = productStatusID
        };

        await dbContext.AddAsync(legoProduct);
        await dbContext.SaveChangesAsync();

        return legoProduct;
    }

    [UseMutationConvention]
    [Error(typeof(NotFoundException))]
    public async Task<LegoProduct> UpdateLegoProduct([Service] LegoContext dbContext, string productID, string productName, string productDisplayName, decimal price, string currencyCode
        , int productStatusID)
    {
        var legoProduct = await dbContext.FindAsync<LegoProduct>(productID);

        if (legoProduct == null)
        {
            throw new NotFoundException(productID, $"LegoProduct {productID} is not existed");
        }

        legoProduct.ProductName = productName;
        legoProduct.ProductDisplayName = productDisplayName;
        legoProduct.Price = price;
        legoProduct.CurrencyCode = currencyCode;
        legoProduct.ProductStatusID = productStatusID;

        dbContext.Update(legoProduct);
        await dbContext.SaveChangesAsync();

        return legoProduct;
    }

    [UseMutationConvention]
    [Error(typeof(NotFoundException))]
    public async Task<LegoProduct> DeleteLegoProduct([Service] LegoContext dbContext, string productID)
    {
        var legoProduct = await dbContext.FindAsync<LegoProduct>(productID);

        if (legoProduct == null)
        {
            throw new NotFoundException(productID, $"LegoProduct {productID} is not existed");
        }

        dbContext.Remove(legoProduct);
        await dbContext.SaveChangesAsync();

        return legoProduct;
    }
    #endregion

    #region LegoProductTheme
    [UseMutationConvention]
    [Error(typeof(ProductThemeDuplicatedException))]
    public async Task<LegoProductTheme> AddLegoProductTheme([Service] LegoContext dbContext, string productThemeID, string productID, int themeID)
    {
        var isExisted = await dbContext.LegoProductThemes.Where(x => x.ProductID == productID && x.ThemeID == themeID).AnyAsync();

        if (isExisted)
        {
            throw new ProductThemeDuplicatedException(productID, themeID, $"Product {productID} has already have theme {themeID}");
        }

        var legoProductTheme = new LegoProductTheme
        {
            ProductThemeID = productThemeID,
            ProductID = productID,
            ThemeID = themeID,
        };

        await dbContext.AddAsync(legoProductTheme);
        await dbContext.SaveChangesAsync();

        return legoProductTheme;
    }

    [UseMutationConvention]
    [Error(typeof(NotFoundException))]
    public async Task<LegoProductTheme> UpdateLegoProductTheme([Service] LegoContext dbContext, string productThemeID, string productID, int themeID)
    {
        var legoProductTheme = await dbContext.FindAsync<LegoProductTheme>(productThemeID);

        if (legoProductTheme == null)
        {
            throw new NotFoundException(productThemeID, $"LegoProductTheme {productThemeID} is not existed");
        }

        legoProductTheme.ProductID = productID;
        legoProductTheme.ThemeID = themeID;

        dbContext.Update(legoProductTheme);
        await dbContext.SaveChangesAsync();

        return legoProductTheme;
    }

    [UseMutationConvention]
    [Error(typeof(NotFoundException))]
    public async Task<LegoProductTheme> DeleteLegoProductTheme([Service] LegoContext dbContext, string productID, int themeID)
    {
        var legoProductTheme = await dbContext.LegoProductThemes.Where(x => x.ProductID == productID && x.ThemeID == themeID).FirstOrDefaultAsync();

        if (legoProductTheme == null)
        {
            throw new NotFoundException(productID, $"Produuct {productID} has no theme {themeID}");
        }

        dbContext.Remove(legoProductTheme);
        await dbContext.SaveChangesAsync();

        return legoProductTheme;
    }
    #endregion
}