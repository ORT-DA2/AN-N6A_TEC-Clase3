using System;
using System.Collections.Generic;
using System.Linq;
using CityInfo.API.Entities;

namespace CityInfo.API.Services
{
    public class CitySevice : ICityService
    {
        private readonly CityInfoContext context;

        public CitySevice(CityInfoContext context)
        {
            this.context = context;
        }

        public City GetCity(int id)
        {
            return this.context.Cities.SingleOrDefault(city => city.Id == id);
        }

        public IEnumerable<City> GetCities(string name)
        {
            var cities = this.context.Cities.ToList();

            return !string.IsNullOrEmpty(name) ?
                cities.Where(city => city.Name.Contains(name, StringComparison.InvariantCultureIgnoreCase)) :
                cities;
        }
    }
}
