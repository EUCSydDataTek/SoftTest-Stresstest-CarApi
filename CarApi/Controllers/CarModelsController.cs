using CarApi.Dto;
using CarApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarModelsController : ControllerBase
    {

        private readonly ICarModelService _CarModelService;

        public CarModelsController(ICarModelService carModelService)
        {
            _CarModelService = carModelService;
        }

        [HttpGet]
        public async Task<List<CarModelDto>> GetCarModels()
        {
            return await _CarModelService.GetCarModelsAsync();
        }
    }
}
