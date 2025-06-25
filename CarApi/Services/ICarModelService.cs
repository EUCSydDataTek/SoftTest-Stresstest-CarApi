using CarApi.Dto;

namespace CarApi.Services
{
    public interface ICarModelService
    {
        Task<List<CarModelDto>> GetCarModelsAsync();
    }
}