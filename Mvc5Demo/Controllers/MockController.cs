namespace Mvc5Demo.Controllers;

[ApiController]
[Route("[controller]")]
public class MockController : Controller
{
    private readonly IMockService _mockService;
    public MockController(IMockService mockService)
    {
        _mockService = mockService;
    }

    [HttpGet]
    public IActionResult Mock()
    {
        return View();
    }

    [HttpGet("SpecialBlog")]
    public async Task<IActionResult> SpecialBlog()
    {
        var str = await _mockService.SpecialBlog();
        return Ok(str);
    }

    [HttpGet("MockData")]
    public async Task<IActionResult> MockData()
    {
        var data = await _mockService.MockData();
        return Ok(data);
    }

    [HttpGet("ErrorCode")]
    public async Task<IActionResult> ErrorCode()
    {
        var errorCode = await _mockService.ErrorCode();
        return Ok(errorCode);
    }
    
    [HttpGet("Temperature/{tc}")]
    public IActionResult TemperatureConversion(double tc)
    {
        var tf = Temperature.CelciusToFahrenheit(tc);

        return Ok("Fahrenheit: " + tf.ToString());
    }
}
