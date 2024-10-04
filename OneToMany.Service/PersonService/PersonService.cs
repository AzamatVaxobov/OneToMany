using OneToMany.DataAccess.Entites;
using OneToMany.Repository.PersonRepository;
using OneToMany.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToMany.Service.PersonService
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public long AddPerson(PersonCreateDto personCreateDto)
        {
            var person = new Person
            {
                FirstName = personCreateDto.FirstName,
                LastName = personCreateDto.LastName
            };

            return _personRepository.InsertPerson(person);
        }

        public ICollection<PersonDto> GetAllPeople()
        {
            var people = _personRepository.SelectAll();
            return people.Select(person => new PersonDto
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Cars = null // Optionally load Cars if needed
            }).ToList();
        }

        public void RemovePerson(long personId)
        {
            _personRepository.DeletePerson(personId);
        }

        public PersonDto GetPersonById(long personId)
        {
            var person = _personRepository.SelectById(personId);
            if (person == null) return null; // Handle not found

            return new PersonDto
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Cars = null // Optionally load Cars if needed
            };
        }

        public void UpdatePerson(PersonDto personDto)
        {
            var person = new Person
            {
                Id = personDto.Id,
                FirstName = personDto.FirstName,
                LastName = personDto.LastName
                // Add other properties if needed
            };

            _personRepository.UpdatePerson(person);
        }

        public PersonDto GetPersonByIdWithCars(long personId)
        {
            var person = _personRepository.GetByIdWithCars(personId);
            if (person == null) return null; // Handle not found

            return new PersonDto
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Cars = person.Cars.Select(car => new CarDto
                {
                    Id = car.Id,
                    Name = car.Name,
                    Color = car.Color,
                    Price = car.Price,
                    PersonId = car.PersonId
                }).ToList() // Assuming you have a CarDto class
            };
        }
    }
}
