using TestDataLoader.Db;
using TestDataLoader.GraphQL.DataLoaders;

namespace TestDataLoader.GraphQL.TypeExtensions;

[ExtendObjectType(typeof(Foo))]
public class FooExtensions
{
    // @TODO: Find out why [Parent(requires)] does not work.
    public async Task<int> GetTotalBarCountAsync(
        [Parent("Id")] Foo foo,
        [Service] IBarCountByFooIdDataLoader barCountByStatusDataLoader,
        CancellationToken ct)
    {
            return await barCountByStatusDataLoader.LoadAsync((foo.Id), ct);
    }
}