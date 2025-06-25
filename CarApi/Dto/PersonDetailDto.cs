namespace CarApi.Dto
{
    public class PersonDetailDto : PersonDto
    {

        public List<CarInfoDto> Cars { get; set; } = default!;

    }
}
