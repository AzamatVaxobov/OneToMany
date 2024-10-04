using Microsoft.EntityFrameworkCore;
using OneToMany.DataAccess;
using OneToMany.DataAccess.Entites;

namespace OneToMany.Repository.PersonRepository;

public class PersonRepository : IPersonRepository
{
    private readonly MainContext _context;

    public PersonRepository(MainContext context)
    {
        _context = context;
    }

    public void DeletePerson(long personId)
    {
        var person = _context.People.FirstOrDefault(st => st.Id == personId);
        if (person != null)
        {
            throw new Exception($"Person with id {{personId}} not found to delete");
        }

        _context.People.Remove(person);
        _context.SaveChanges();

    }

    public long InsertPerson(Person person)
    {
        _context.People.Add(person);
        _context.SaveChanges();
        return person.Id;
    }

    public ICollection<Person> SelectAll()
    {
        return _context.People.ToList();
    }

    public Person SelectById(long personId)
    {
        var person = _context.People.FirstOrDefault(p => p.Id == personId);
        if (person == null)
        {
            throw new Exception($"Person with id {personId} not found");
        }

        return person;
    }

    public void UpdatePerson(Person person)
    {
        var existingPerson = _context.People.Include(p => p.Cars).FirstOrDefault(p => p.Id == person.Id);

        if (existingPerson == null)
        {
            throw new Exception($"Person with id {person.Id} not found to update");
        }

        // Update basic properties
        existingPerson.FirstName = person.FirstName;
        existingPerson.LastName = person.LastName;

        _context.SaveChanges();
    }
    public Person GetByIdWithCars(long personId)
    {
        var person = _context.People
            .Include(p => p.Cars) // Eagerly load the Cars collection
            .FirstOrDefault(p => p.Id == personId);

        if (person == null)
        {
            throw new Exception($"Person with id {personId} not found");
        }

        return person;
    }
}