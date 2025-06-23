namespace CarApi.Data.Entities
{
    public class Car
    {
        public int CarId { get; set; }

        public string Name { get; set; } = string.Empty;

        public CarModel Model { get; set; } = default!;

        public Person Owner { get; set; } = default!;
    }
}
