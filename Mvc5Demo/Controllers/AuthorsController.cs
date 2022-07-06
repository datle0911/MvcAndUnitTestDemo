namespace Mvc5Demo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController : Controller
{
    private readonly IAuthorService _authorService;
    public AuthorsController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAuthors()
    {
        var authors = await _authorService.GetAllAuthors();

        return Ok(authors);
    }
}
