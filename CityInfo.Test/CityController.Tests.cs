using System.Collections.Generic;
using CityInfo.API.Controllers;
using CityInfo.API.Entities;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CityInfo.Test
{
    [TestClass]
    public class UnitTest1
    {
        // ------ERROR MADE iN CLASS-------
        /*[TestMethod] 
        public void TestGetCitiesShouldReturnOK()
        {
            // Context cannot be mocked, that's why you use ef in memory instead, only for testing propouses
            var mock = new Mock<CityInfoContext>(It.IsAny<DbContextOptions<CityInfoContext>>());
            var sut = new CitiesController(mock.Object);

            var response = sut.GetCities(null);

            var result = response as OkObjectResult;
            Assert.AreEqual(200,result.StatusCode);
        }*/

        [TestMethod]
        public void TestGetCitiesShouldReturnOK()
        {
            var mock = new Mock<ICityService>();
            var sut = new CitiesController(mock.Object);

            var response = sut.GetCities(null);

            var result = response as OkObjectResult;
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void TestGetCitiesShouldReturnOKFailsCauseMockBehaviorStrict()
        {
            var mock = new Mock<ICityService>(MockBehavior.Strict);
            var sut = new CitiesController(mock.Object);

            var response = sut.GetCities(null);

            var result = response as OkObjectResult;
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public void TestGetCitiesShouldReturnOKReturnCities()
        {
            var mock = new Mock<ICityService>(MockBehavior.Strict);
            mock.Setup(m => m.GetCities(It.IsAny<string>())).Returns(new List<City> { new City(), new City() });

            var sut = new CitiesController(mock.Object);
            var inputValue = "randomValue since it expect any string value, even null";

            var response = sut.GetCities(inputValue);

            mock.Verify(m => m.GetCities(inputValue), Times.Once);

            var result = response as OkObjectResult;
            var model = result.Value as List<City>;
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(2, model.Count);
        }
    }
}
