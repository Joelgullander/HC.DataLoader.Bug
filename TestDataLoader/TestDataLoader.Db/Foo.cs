using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestDataLoader.Db;

public class Foo
{
    [Key]
    [HotChocolate.ApolloFederation.Types.Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [IsProjected(true)]
    public Guid Id { get; set; }

    public string Name { get; set; }
    
    public ICollection<Bar> Bars { get; set; }

}