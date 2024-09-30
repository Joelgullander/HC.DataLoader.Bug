using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestDataLoader.Db;

public class Baz
{
    [Key]
    [HotChocolate.ApolloFederation.Types.Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string Name { get; set; }
    
    // public Guid FooId { get; set; }

}