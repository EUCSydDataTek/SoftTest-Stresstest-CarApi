using System.ComponentModel.DataAnnotations.Schema;

namespace CarApi.Data.Entities
{
    public class Car
    {
        public int CarId { get; set; }

        [ForeignKey(nameof(Model))]
        public int ModelId { get; set; }

        [ForeignKey(nameof(Owner))]
        public int PersonId { get; set; }

        public string Name { get; set; } = string.Empty;

        public CarModel Model { get; set; } = default!;

        public Person Owner { get; set; } = default!;
    }
}
