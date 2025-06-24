namespace CarApi.Dto
{
    public class CarInfoDetailDto : CarInfoDto
    {
        public int ModelId { get; set; }

        public int OwnerId { get; set; }
    }
}
