using CarApi.Data;
using CarApi.Data.Entities;
using CarApi.Dto;
using Microsoft.EntityFrameworkCore;

namespace CarApi.Services
{
    public class CarService : ICarService
    {

        private readonly AppDbContext _context;
        private readonly ILogger<CarService> _logger;

        public CarService(AppDbContext context, ILogger<CarService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<CarInfoDto>> GetCarsAsync()
        {
            return await _context.Cars
                                 .Include(c => c.Owner)
                                 .Include(c => c.Model)
                                 .Select(c => c.ToCarInfoDto()).ToListAsync();
        }

        public async Task<CarInfoDetailDto?> GetCarAsync(int CarId)
        {
            var car = await _context.Cars
                                    .Include(c => c.Owner)
                                    .Include(c => c.Model)
                                    .Where(c => c.CarId == CarId).FirstOrDefaultAsync();

            return car?.ToCarInfoDetailDto();
        }

        public async Task<CarInfoDetailDto> CreateCarAsync(CreateCarDto CarDto)
        {
            Car car = new()
            {
                Name = CarDto.CarName,
                ModelId = CarDto.ModelId
            };

            if (CarDto.OwnerId == 0)
            {
                car.Owner = new()
                {
                    FirstName = CarDto?.OwnerFirstName ?? "john",
                    LastName = CarDto?.OwnerLastName ?? "doe",
                };
            }
            else
            {
                car.PersonId = CarDto.OwnerId ?? 0;
            }

            _context.Cars.Add(car);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                throw new Exception("Saving changes to database failed.");
            }

            await _context.Entry(car).Reference(c => c.Model).LoadAsync();
            await _context.Entry(car).Reference(c => c.Owner).LoadAsync();

            return car.ToCarInfoDetailDto();
        }

        public async Task<CarInfoDetailDto> EditCarAsync(int CarId,EditCarDto CarDto)
        {
            Car? car = _context.Cars.Where(c => c.CarId == CarId).FirstOrDefault();

            if (car == null)
            {
                return null!;
            }

            car.Name = CarDto.CarName;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e,e.Message);
                throw new Exception("Saving changes to database failed.");
            }

            await _context.Entry(car).Reference(c => c.Model).LoadAsync();
            await _context.Entry(car).Reference(c => c.Owner).LoadAsync();

            return car.ToCarInfoDetailDto();
        }

        public async Task RemoveCarAsync(int CarId)
        {
            var car = await _context.Cars.Where(c => c.CarId == CarId).FirstOrDefaultAsync();

            if (car != null)
            {
                _context.Cars.Remove(car);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    _logger.LogError(e, e.Message);
                    throw new Exception("Saving changes to database failed.");
                }


            }
        }
    }
}
