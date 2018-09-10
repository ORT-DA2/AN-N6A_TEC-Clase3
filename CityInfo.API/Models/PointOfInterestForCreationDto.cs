
using System.ComponentModel.DataAnnotations;

namespace CityInfo.API.Models
{
    public class PointOfInterestForCreationDto
    {
        [Required(ErrorMessage = "You should provide a valid name")]
        public string Name { get; set; }

        [MaxLength(25)]
        public string Description { get; set; }
    }
}
