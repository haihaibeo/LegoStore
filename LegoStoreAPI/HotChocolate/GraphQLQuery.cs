using Infrastructure.DataAccess.Context;
using Infrastructure.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace LegoStoreAPI.HotChocolate;

public class GraphQLQuery
{
    [UseOffsetPaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<LegoProduct> GetLegoProducts([Service] LegoContext dbContext)
        => dbContext.LegoProducts.AsNoTracking();

    [UseOffsetPaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<LegoProductStatus> GetLegoProductStatuses([Service] LegoContext dbContext)
        => dbContext.LegoProductStatuses.AsNoTracking();

    [UseOffsetPaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<LegoProductTheme> GetLegoProductThemes([Service] LegoContext dbContext)
        => dbContext.LegoProductThemes.AsNoTracking();

    [UseOffsetPaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Theme> GetThemes([Service] LegoContext dbContext)
        => dbContext.Themes.AsNoTracking();
}