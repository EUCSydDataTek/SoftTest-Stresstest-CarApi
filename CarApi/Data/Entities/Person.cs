namespace CarApi.Data.Entities
{
    public class Person
    {

        public int PersonId { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; }

        public List<Car> cars { get; set; }
    }
}
