using System;
using System.Linq;
using CityInfo.API.Entities;
using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [Route("api/cities")]  // [Route("api/[controller]")]
    public class CitiesController : Controller
    {
        [HttpGet()]
        public IActionResult GetCities([FromQuery] string name)
        {
            var cities = CityDataStore.Current.Cities;

            return Ok(!string.IsNullOrEmpty(name) ? 
                cities.Where(city => city.Name.Contains(name, StringComparison.InvariantCultureIgnoreCase)) : 
                cities);
        }

        //[HttpGet("{id}")]
        //public JsonResult GetCity(int id)
        //{
        //    return new JsonResult(CityDataStore.Current.Cities.FirstOrDefault(city => city.Id == id));
        //}


        // set proper status code when not found
        [HttpGet("{id}")]
        public IActionResult GetCity(int id)
        {
            var cityMacth = CityDataStore.Current.Cities.FirstOrDefault(city => city.Id == id);

            if (cityMacth == null)
            {
                return NotFound();
            }

            return Ok(cityMacth);
            // IActionResult allows us to return other format types, not only json
        }

        public void Post(CityDto dto)
        {
            using (var db = new CityInfoContext())
            {
                db.Cities.Add(new City {Name = dto.Name, Description = dto.Description});

                db.SaveChanges();
            }
        }

    }
}