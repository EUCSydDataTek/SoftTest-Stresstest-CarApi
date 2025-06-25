namespace CarApi.Dto
{
    public class PersonDto
    {
        public int PersonId { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public int CarsOwned {  get; set; }
    }
}
