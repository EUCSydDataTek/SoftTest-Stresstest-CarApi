using CarApi.Data.Entities;
using CarApi.Dto;
using System.Runtime.CompilerServices;

namespace CarApi.Services
{
    public static class DtoExtensions
    {

        #region Car

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

        #endregion Car

        #region Person

        public static PersonDto ToPersonDto(this Person person)
        {
            return new()
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                PersonId = person.PersonId,
                CarsOwned = person.cars.Count()
            };
        }

        public static PersonDetailDto TodoPersonDetailDto(this Person person)
        {
            PersonDetailDto p = new()
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                PersonId = person.PersonId,
                CarsOwned = person.cars.Count(),
            };

            p.Cars = person.cars.Select(c => c.ToCarInfoDto()).ToList();

            return p;
        }

        #endregion Person

        public static CarModelDto ToCarModelDto(this CarModel model)
        {
            return new()
            {
                ModelId = model.CarModelId,
                Name = model.ModelName,
                Manufacturer = model.Manufacturer
            };
        }
    }
}
