namespace CarApi.Dto
{
    public class CreateCarDto
    {

        /// <summary>
        /// The name of the car
        /// </summary>
        public string CarName { get; set; }

        /// <summary>
        /// Id of the Car model
        /// </summary>
        public int ModelId { get; set; }

        /// <summary>
        /// OwnerId (If the person already exists) 
        /// If the field is empty it will create a new owner with OwnerFirstName and OwnerLastName
        /// </summary>
        public int? OwnerId { get; set; }

        /// <summary>
        /// Creates a new owner when filled
        /// </summary>
        public string? OwnerFirstName { get; set; }

        /// <summary>
        /// Creates a new owner when filled
        /// </summary>
        public string? OwnerLastName { get; set; }
    }
}
