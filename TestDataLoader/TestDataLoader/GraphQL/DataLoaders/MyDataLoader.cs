using GreenDonut.Projections;
using Microsoft.EntityFrameworkCore;
using TestDataLoader.Db;

namespace TestDataLoader.GraphQL.DataLoaders;

public class MyDataLoader
{
    [DataLoader]
    public static async Task<Dictionary<Guid, Foo>> GetFooByIdAsync(
        IReadOnlyList<Guid> ids,
        ApplicationDbContext context,
        ISelectorBuilder selection,
        CancellationToken ct)
        => await context.Foos
            .Where(t => ids.Contains(t.Id))
            .Select(selection, f => f.Id)
            .ToDictionaryAsync(t => t.Id, ct);
    
    [DataLoader]
    public static async Task<Dictionary<Guid, int>> GetBarCountByFooIdAsync(
        IReadOnlyList<Guid> ids,
        ApplicationDbContext context,
        CancellationToken ct)
    {
        return await context.Bars
            .Where(r => ids.Contains(r.FooId))
            .GroupBy(r => r.FooId)
            .Select(g => new { FooId = g.Key, Count = g.Count() })
            .ToDictionaryAsync(x => x.FooId, x => x.Count, ct);
    }
}