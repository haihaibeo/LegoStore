using HotChocolate.Types.Pagination;
using Infrastructure;
using Infrastructure.DataAccess.Context;
using LegoStoreAPI.HotChocolate;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add EF Core
builder.Services.AddDbContext<LegoContext>(c =>
                    c.UseSqlServer(builder.Configuration.GetConnectionString("LegoDBCnn")));

// Add HotChocolate
builder.Services
    .AddGraphQLServer()
    .RegisterDbContext<LegoContext>(DbContextKind.Resolver)
    .AddQueryType<GraphQLQuery>()
    .AddFiltering()
    .AddSorting()
    .AddProjections()
    .SetPagingOptions(new PagingOptions
    {
        IncludeTotalCount = true,
    })
    .AddMutationType<GraphQLMutation>()
    .AddMutationConventions()
    .AddDefaultTransactionScopeHandler()
    .InitializeOnStartup();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.MapGraphQL();

app.Run();