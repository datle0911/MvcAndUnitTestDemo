using Microsoft.VisualStudio.TestTools.UnitTesting;

using Mvc5Demo.Controllers;
using Mvc5Demo.Services;
using Mvc5Demo.Models;

using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestProject;
[TestClass]
public class TemperatureConversionTest
{

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