using System.Collections.Generic;

namespace CityInfo.API.Entities
{
    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int NumberOfPointsOfInterest => this.PointsOfInterest.Count;

        public List<PointOfInterest> PointsOfInterest { get; set; } = new List<PointOfInterest>();

        public CityImage Image { get; set; }
    }
}
