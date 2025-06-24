using CarApi.Data.Entities;
using CarApi.Dto;
using System.Runtime.CompilerServices;

namespace CarApi.Services
{
    public static class DtoExtensions
    {

        public static CarInfoDto ToCarInfoDto(this Car car)
        {
            return new CarInfoDto()
            {
                CarId = car.CarId,
                CarName = car.Name,
                CarModel = $"{car.Model.Manufacturer} {car.Model.ModelName}",
                CarOwner = $"{car?.Owner.FirstName} {car?.Owner.LastName}"
            };
        }

        public static CarInfoDetailDto ToCarInfoDetailDto(this Car car)
        {
            return new CarInfoDetailDto()
            {
                CarId = car.CarId,
                CarName = car.Name,
                CarModel = $"{car.Model.Manufacturer} {car.Model.ModelName}",
                CarOwner = $"{car?.Owner.FirstName} {car?.Owner.LastName}",
                ModelId = car.ModelId,
                OwnerId = car.Owner.PersonId
            };
        }

    }
}
