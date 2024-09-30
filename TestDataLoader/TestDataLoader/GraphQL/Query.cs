using GreenDonut.Projections;
using HotChocolate.Execution.Processing;
using TestDataLoader.Db;
using TestDataLoader.GraphQL.DataLoaders;

namespace TestDataLoader.GraphQL;

public class Query
{
    [UseProjection]
    // public IQueryable<Foo> GetFoos([Service] ApplicationDbContext _context) =>
    //     _context.Foos;

    public Task<Foo?> GetFooAsync(
        IFooByIdDataLoader dataLoader,
        Guid fooId,
        ISelection selection,
        CancellationToken ct)
            => dataLoader.Select(selection).LoadAsync(fooId, ct);
}