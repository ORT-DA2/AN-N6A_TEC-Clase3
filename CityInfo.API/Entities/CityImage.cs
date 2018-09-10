
namespace CityInfo.API.Entities
{
    public class CityImage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public byte[] Image { get; set; }
    }
}
