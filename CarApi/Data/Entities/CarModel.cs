namespace CarApi.Data.Entities
{
    public class CarModel
    {
        public int CarModelId { get; set; }

        public string ModelName { get; set; }

        public string Manufacturer { get; set; } = string.Empty;
    }
}
