using Bogus.Extensions.UnitedKingdom;
using CarApi.Dto;
using CarApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {

        private readonly IPersonService _personService;

        public PeopleController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<List<PersonDto>> GetPeople()
        {
            return await _personService.GetPeopleAsync();
        }

        [HttpGet("{PersonId}",Name = "GetPerson")]
        public async Task<ActionResult<PersonDetailDto>> GetPersonAsync(int PersonId)
        {
            var person = await _personService.GetPersonAsync(PersonId);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        [HttpPost]
        public async Task<ActionResult<PersonDto>> CreatePerson(CreatePersonDto personDto)
        {
            try
            {
                var person = await _personService.CreatePersonAsync(personDto);
                return CreatedAtAction("GetPerson", new { PersonId = person.PersonId },person);
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpPut("{PersonId}")]
        public async Task<ActionResult<PersonDto>> EditPerson(int PersonId,EditPersonDto personDto)
        {
            try
            {
                var person = await _personService.EditPersonAsync(PersonId, personDto);

                if (person == null)
                {
                    return NotFound();
                }

                return person;
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemovePerson(int PersonId)
        {
            await _personService.RemovePersonAsync(PersonId);

            return NoContent();
        }
    }
}
