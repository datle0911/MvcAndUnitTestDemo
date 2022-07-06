namespace Mvc5Demo.Models;

public class Temperature
{
    public static double CelciusToFahrenheit(double Tc)
    {
        double Tf;
        Tf = (Tc*9/5) + 32;
        return Tf;
    }
}
