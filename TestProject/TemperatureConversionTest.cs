using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject;
[TestClass]
public class TemperatureConversionTest
{

    [TestMethod]
    public void Test()
    {
        double tc = 22;
        double tf = Temperature.CelciusToFahrenheit(tc);
        double expectedTf = 71.6;

        Assert.AreEqual(tf, expectedTf, 0.001, "Wrong Conversion");
    }
}