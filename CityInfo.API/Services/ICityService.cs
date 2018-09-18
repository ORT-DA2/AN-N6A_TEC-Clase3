using System.Collections.Generic;
using CityInfo.API.Entities;

namespace CityInfo.API.Services
{
    public interface ICityService
    {
        City GetCity(int id);

        IEnumerable<City> GetCities(string name);
    }
}