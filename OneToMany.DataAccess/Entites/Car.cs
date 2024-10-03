namespace OneToMany.DataAccess.Entites;

public class Car
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
    public decimal Price { get; set; }

    public long PersonId { get; set; }
    public Person Person { get; set; }
}
