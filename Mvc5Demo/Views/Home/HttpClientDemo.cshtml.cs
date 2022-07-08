using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mvc5Demo.Views.Mock
{
    public class TemperatureModel : PageModel
    {
        public double CelciusTemperature { get; set; }
        public double FahrenheitTemperature { get; set; }
        public void OnGet()
        {
        }
        
        public void OnPost()
        {
            CelciusTemperature = Convert.ToDouble(Request.Form["Temperature in C"]);

            FahrenheitTemperature = Temperature.CelciusToFahrenheit(CelciusTemperature);
        }
    }
}
