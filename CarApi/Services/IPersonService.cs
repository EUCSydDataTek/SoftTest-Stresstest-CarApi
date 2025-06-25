using CarApi.Dto;

namespace CarApi.Services
{
    public interface IPersonService
    {
        Task<PersonDto> CreatePersonAsync(CreatePersonDto person);
        Task<PersonDto?> EditPersonAsync(int PersonId, EditPersonDto person);
        Task<List<PersonDto>> GetPeopleAsync();
        Task<PersonDetailDto?> GetPersonAsync(int PersonId);
        Task RemovePersonAsync(int PersonId);
    }
}