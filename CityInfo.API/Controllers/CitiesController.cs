using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [Route("api/cities")]  // [Route("api/[controller]")]
    public class CitiesController : Controller
    {
        private readonly ICityService cityService;
        public CitiesController(ICityService service)
        {
            this.cityService = service;
        }


        [HttpGet()]
        public IActionResult GetCities([FromQuery] string name)
        {
            return Ok(this.cityService.GetCities(name));
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
            var cityMacth = this.cityService.GetCity(id);

            if (cityMacth == null)
            {
                return NotFound();
            }

            return Ok(cityMacth);
            // IActionResult allows us to return other format types, not only json
        }

        public void Post(CityDto dto)
        {
            // this.context.Cities.Add(new City { Name = dto.Name, Description = dto.Description });

            // this.context.SaveChanges();
        }

    }
}