using Microsoft.EntityFrameworkCore;

namespace TestDataLoader.Db;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Optional: Seed data directly in the model
        modelBuilder.Entity<Foo>().HasData(
            new Foo { Id = new Guid("af83d886-bfa4-4c4e-18bd-08dcdd6a18db"), Name = "Foo 1" },
            new Foo { Id = new Guid("335950de-18fd-4b49-8e0e-c01516c5ef0f"), Name = "Foo 2" }
        );
        
        modelBuilder.Entity<Bar>().HasData(
            new Bar { Id = new Guid("7216de35-ab08-4809-bea4-89bce62577bf"), Name = "Bar 1", FooId = new Guid("af83d886-bfa4-4c4e-18bd-08dcdd6a18db")},
            new Bar { Id = new Guid("f8cedc4f-82c6-4d38-8d00-07559344d7df"), Name = "Bar 2", FooId = new Guid("af83d886-bfa4-4c4e-18bd-08dcdd6a18db") }
        );
    }

    public DbSet<Foo> Foos { get; set; }
    public DbSet<Bar> Bars { get; set; }
}