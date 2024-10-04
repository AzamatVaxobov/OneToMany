using Microsoft.EntityFrameworkCore;
using OneToMany.DataAccess.Entites;

namespace OneToMany.DataAccess;

public class MainContext : DbContext
{
    public DbSet<Person> People { get; set; }
    public DbSet<Car> Cars { get; set; }

    public MainContext(DbContextOptions<MainContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
