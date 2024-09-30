using Microsoft.EntityFrameworkCore;
using TestDataLoader.Db;
using TestDataLoader.GraphQL;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("FooDb"));

builder.Services
    .AddGraphQLServer()
    .AddSorting()
    .AddProjections()
    .AddFiltering()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddAssetTypes()
    .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true)
    .AddApolloFederation();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.EnsureCreated();  // Ensures the in-memory database is created
}

app.UseRouting();
app.UseEndpoints(c =>
{
    c.MapGraphQL();
    c.MapBananaCakePop();
});


app.RunWithGraphQLCommands(args);