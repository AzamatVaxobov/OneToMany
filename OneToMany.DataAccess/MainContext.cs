using Microsoft.EntityFrameworkCore;
using OneToMany.DataAccess.Entites;

namespace OneToMany.DataAccess;

public class MainContext : DbContext
{
    public DbSet<Person> People { get; set; }
}
