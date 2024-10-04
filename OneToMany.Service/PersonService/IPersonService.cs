using OneToMany.Service.DTOs;

namespace OneToMany.Service.PersonService
{
    public interface IPersonService
    {
        long AddPerson(PersonCreateDto personCreateDto);
        ICollection<PersonDto> GetAllPeople();
        void RemovePerson(long personId);
        PersonDto GetPersonById(long personId);
        void UpdatePerson(PersonDto personDto); // For updating a person
        PersonDto GetPersonByIdWithCars(long personId);
    }
}