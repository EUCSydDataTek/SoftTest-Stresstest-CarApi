using CarApi.Dto;

namespace CarApi.Services
{
    public interface ICarService
    {
        Task<CarInfoDetailDto> CreateCarAsync(CreateCarDto CarDto);
        Task<CarInfoDetailDto> EditCarAsync(int CarId,EditCarDto CarDto);
        Task<CarInfoDetailDto?> GetCarAsync(int CarId);
        Task<List<CarInfoDto>> GetCarsAsync();
        Task RemoveCarAsync(int CarId);
    }
}