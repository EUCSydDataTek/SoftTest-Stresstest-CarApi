using CarApi.Data;
using CarApi.Data.Entities;
using CarApi.Dto;
using Microsoft.EntityFrameworkCore;

namespace CarApi.Services
{
    public class PersonService : IPersonService
    {

        private readonly AppDbContext _context;
        private readonly ILogger<PersonService> _logger;

        public PersonService(AppDbContext context, ILogger<PersonService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<PersonDto>> GetPeopleAsync()
        {
            return await _context.Persons
                                 .Include(p => p.cars)
                                 .Select(p => p.ToPersonDto())
                                 .ToListAsync();
        }

        public async Task<PersonDetailDto?> GetPersonAsync(int PersonId)
        {
            var person = await _context.Persons
                                       .Where(p => p.PersonId == PersonId)
                                       .Include(p => p.cars)
                                       .ThenInclude(c => c.Model)
                                       .FirstOrDefaultAsync();

            if (person == null)
            {
                return null;
            }

            return person.TodoPersonDetailDto();
        }

        public async Task<PersonDto> CreatePersonAsync(CreatePersonDto person)
        {
            Person newPerson = new()
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
            };

            _context.Persons.Add(newPerson);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                throw new Exception("Person cant be created due to database errors");
            }

            await _context.Entry(newPerson).Collection(p => p.cars).LoadAsync();

            return newPerson.ToPersonDto();
        }

        public async Task<PersonDto?> EditPersonAsync(int PersonId, EditPersonDto person)
        {
            var EditPerson = await _context.Persons.Where(p => p.PersonId == PersonId).FirstOrDefaultAsync();

            if (EditPerson == null)
            {
                return null;
            }

            EditPerson.FirstName = person.FirstName;
            EditPerson.LastName = person.LastName;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                throw new Exception("Person cant be edited due to database errors");
            }

            await _context.Entry(EditPerson).Collection(p => p.cars).LoadAsync();

            return EditPerson.ToPersonDto();
        }

        public async Task RemovePersonAsync(int PersonId)
        {
            var person = await _context.Persons.Where(p => p.PersonId == PersonId).FirstOrDefaultAsync();

            if (person == null)
            {
                return;
            }
            else
            {
                _context.Persons.Remove(person);

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return;
                }
            }
        }
    }
}
