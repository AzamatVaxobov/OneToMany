namespace OneToMany.DataAccess.Entites;

public class Person
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public ICollection<Car> Cars { get; set; }
}
