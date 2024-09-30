using TestDataLoader.Db;
using TestDataLoader.GraphQL.InputTypes;

namespace TestDataLoader.GraphQL;

public class Mutation
{
    public Foo AddFoo([Service] ApplicationDbContext _context, FooInputType foo)
    {
        var fooEntity = new Foo
        {
            Name = foo.Name
        };
        var created = _context.Foos.Add(fooEntity);
        _context.SaveChanges();

        return created.Entity;
    }
}