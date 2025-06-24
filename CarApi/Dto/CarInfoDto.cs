namespace CarApi.Dto
{
    public class CarInfoDto
    {
        /// <summary>
        /// The Id of the car
        /// </summary>
        public int CarId { get; set; }

        /// <summary>
        /// The name of the car
        /// </summary>
        public string CarName { get; set; } = string.Empty;

        /// <summary>
        /// The Full name of the cars owner
        /// </summary>
        public string CarOwner { get; set; } = string.Empty;

        /// <summary>
        /// The full name of the model (Manufacturer + model)
        /// </summary>
        public string CarModel { get; set; } = string.Empty;
    }
}
