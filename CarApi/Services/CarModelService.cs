using CarApi.Data;
using CarApi.Dto;
using Microsoft.EntityFrameworkCore;

namespace CarApi.Services
{
    public class CarModelService : ICarModelService
    {

        private readonly AppDbContext _context;

        public CarModelService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CarModelDto>> GetCarModelsAsync()
        {
            return await _context.CarModels.Select(m => m.ToCarModelDto()).ToListAsync();
        }
    }
}
