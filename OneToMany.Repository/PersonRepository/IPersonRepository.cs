using OneToMany.DataAccess.Entites;

namespace OneToMany.Repository.PersonRepository
{
    public interface IPersonRepository
    {
        long InsertPerson(Person person);
        void DeletePerson(long personId);
        ICollection<Person> SelectAll();
        Person SelectById(long id);
        public void UpdatePerson(Person person);
        public Person GetByIdWithCars(long personId);
    }
}