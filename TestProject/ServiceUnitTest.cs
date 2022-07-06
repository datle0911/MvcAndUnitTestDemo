using Microsoft.VisualStudio.TestTools.UnitTesting;

using Mvc5Demo.Controllers;
using Mvc5Demo.Services;
using Mvc5Demo.Models;

using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestProject;
[TestClass]
public class ServiceUnitTest
{

    //[TestMethod]
    //public async void SpecialBlogTest()
    //{
    //    // Arrange

    //    // Act
    //    var result = _mockService.SpecialBlog();

    //    // Assert
    //    Assert.IsTrue(result.Result.Length > 0);
    //}

    //[TestMethod]
    //public async void MockDataTest()
    //{
    //    // Arrange
    //    var mockService = new MockService(_httpClientFactory);

    //    // Act
    //    var result = await mockService.MockData();

    //    // Assert
    //    Assert.IsTrue(result.Length > 0);
    //}

    //[TestMethod]
    //public async void ErrorCodeTest()
    //{
    //    // Arrange
    //    var mockService = new MockService(_httpClientFactory);

    //    // Act
    //    var result = await mockService.ErrorCode();

    //    // Assert
    //    Assert.IsTrue(result == 403);
    //}

    [TestMethod]
    public void TestTemperatureConversion()
    {
        double tc = 22;
        double tf;
        double expectedTf = 71.6;

        tf = Temperature.CelciusToFahrenheit(tc);

        Assert.AreEqual(tf, expectedTf, 0.001, "Wrong Conversion");
    }
}