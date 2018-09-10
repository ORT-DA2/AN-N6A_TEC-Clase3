using System.Collections.Generic;
using CityInfo.API.Models;

namespace CityInfo.API
{
    public class CityDataStore
    {
        public static CityDataStore Current { get; } = new CityDataStore(); //auto-property initializer C#6

        public List<CityDto> Cities { get; set; }

        public CityDataStore()
        {
            Cities = new List<CityDto>
            {
                new CityDto()
                {
                    Id = 1,
                    Name = "New York City",
                    Description = "Great park in the middle",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto(){Id = 10,Name = "Point 10", Description = "Welcome to point 10"},
                        new PointOfInterestDto(){Id = 11,Name = "Point 11", Description = "Welcome to point 11"},
                        new PointOfInterestDto(){Id = 12,Name = "Point 12", Description = "Welcome to point 12"}
                    }
                },
                new CityDto()
                {
                    Id = 2,
                    Name = "Boston",
                    Description = "Full of nerds",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto(){Id = 13,Name = "Point 13", Description = "Welcome to point 13"},
                        new PointOfInterestDto(){Id = 14,Name = "Point 14", Description = "Welcome to point 14"},
                        new PointOfInterestDto(){Id = 15,Name = "Point 15", Description = "Welcome to point 15"}
                    }
                },
                new CityDto()
                {
                    Id = 3,
                    Name = "London",
                    Description = "Excellent tea",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto(){Id = 16,Name = "Point 16", Description = "Welcome to point 16"}
                    }
                }
            };
        }
    }
}
