using Bogus;
using CarApi.Data.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace CarApi.Data
{
    public static class DemoCreationExtensions
    {

        public static async Task CreateDemoDataAsync(this AppDbContext context,int amount)
        {
            context.Add(CreateCarsContext(amount));

            await context.SaveChangesAsync();
        }

        public static Entities.Person CreatePerson() {

            Faker<Entities.Person> faker = new Faker<Entities.Person>()
                                           .RuleFor(p => p.FirstName, f => f.Person.FirstName)
                                           .RuleFor(p => p.LastName, f => f.Person.LastName);

            return faker.Generate();
        }

        public static Entities.CarModel CreateCarModel()
        {
            Faker<Entities.CarModel> faker = new Faker<Entities.CarModel>()
                                        .RuleFor(c => c.ModelName, f => f.Vehicle.Model())
                                        .RuleFor(c => c.Manufacturer, f => f.Vehicle.Manufacturer());

            return faker.Generate();
        }

        public static List<Entities.Car> CreateCarsContext(int amount)
        {
            var list = new List<Entities.Car>();

            Faker<Entities.Car> faker = new Faker<Car>()
                                        .RuleFor(c => c.Name, f => f.Hacker.Verb());

            var CarModelsCreated = new List<Entities.CarModel>();
            var PeopleCreated = new List<Entities.Person>();

            foreach (var car in faker.Generate(amount))
            {
                car.Owner = CreatePerson();
                car.Model = CreateCarModel();

                CarModelsCreated.Add(car.Model);
                PeopleCreated.Add(car.Owner);

                list.Add(car);
            }

            foreach (var person in PeopleCreated)
            {
                if (Random.Shared.Next(0,2) >= 1)
                {
                    int modelIndex = Random.Shared.Next(0,CarModelsCreated.Count);

                    var carModel = CarModelsCreated[modelIndex];

                    var car = faker.Generate();

                    car.Owner = person;
                    car.Model = carModel;

                    list.Add(car);
                }
            }

            return list;
        }
    }
}
