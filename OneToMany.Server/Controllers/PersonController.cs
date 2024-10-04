using Microsoft.AspNetCore.Mvc;
using OneToMany.Service.DTOs;
using OneToMany.Service.PersonService;

namespace OneToMany.Server.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost]
        public long AddPerson(PersonCreateDto personCreateDto)
        {
            var personId = _personService.AddPerson(personCreateDto);
            return personId;
        }

        [HttpDelete("{personId}")]
        public void DeletePerson(long personId)
        {
            _personService.RemovePerson(personId);
        }

        [HttpGet]
        public ICollection<PersonDto> GetAllPeople()
        {
            var people = _personService.GetAllPeople();
            return people;
        }

        [HttpGet("{personId}")]
        public PersonDto GetPersonById(long personId)
        {
            var person = _personService.GetPersonById(personId);
            return person;
        }
    }
}

