using CarApi.Dto;
using CarApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CarInfoDto>>> GetCars()
        {
            return await _carService.GetCarsAsync();
        }

        [HttpGet("{CarId}",Name = "GetCar")]
        public async Task<ActionResult<CarInfoDetailDto>> GetCar(int CarId)
        {
            var car = await _carService.GetCarAsync(CarId);

            if (car == null)
            {
                return NotFound();
            }
            else
            {
                return car;
            }
        }

        [HttpPost()]
        public async Task<ActionResult<CarInfoDetailDto>> CreateCar(CreateCarDto carDto)
        {
            try
            {
                var car = await _carService.CreateCarAsync(carDto);

                return CreatedAtAction(nameof(GetCar),new { car.CarId }, car);
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpPut("{CarId}")]
        public async Task<ActionResult<CarInfoDetailDto>> EditCar(int CarId,EditCarDto carDto)
        {
            var car = await _carService.EditCarAsync(CarId,carDto);

            if (car == null)
            {
                return UnprocessableEntity();
            }
            else
            {
                return car;
            }
        }

        [HttpDelete("{CarId}")]
        public async Task<IActionResult> DeleteCar(int CarId)
        {
            try
            {
                await _carService.RemoveCarAsync(CarId);
                return NoContent();
            }
            catch (Exception)
            {
                return NoContent();
            }
            
        }
    }
}
