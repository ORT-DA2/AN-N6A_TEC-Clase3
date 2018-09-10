
using System.IO;
using System.Linq;
using CityInfo.API.Entities;
using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.Controllers
{
    [Route("api/cityimage")]
    public class CityImageController : Controller
    {
        [HttpPost()]
        public void SaveImage(CityImageDto dto)
        {
            using (var db = new CityInfoContext())
            {
                var city = db.Cities.FirstOrDefault(c => c.Id == dto.CityId);

                var file = HttpContext.Request.Form.Files.GetFile("image");

                var cityImage = new CityImage { Name = dto.FileName, ContentType = file.ContentType};

                using (var memoryStream = new MemoryStream())
                {
                    file.CopyTo(memoryStream);
                    cityImage.Image = memoryStream.ToArray();
                }

                city.Image = cityImage;

                db.SaveChanges();
            }
        }

        [HttpGet("{cityId}")]
        public IActionResult Download(int cityId)
        {

            using (var db = new CityInfoContext())
            {
                // var city = db.Cities.FirstOrDefault(c => c.Id == cityId);
                // TODO: why we need the include?
                var city = db.Cities.Include(c => c.Image).FirstOrDefault(c => c.Id == cityId);

                return File(city.Image.Image, city.Image.ContentType);
            }


        }
    }
}
