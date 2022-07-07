namespace Mvc5Demo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : Controller
{
    private readonly IBookService _bookService;
    private readonly IAuthorService _authorService;
    public BooksController(IBookService bookService, IAuthorService authorService)
    {
        _bookService = bookService;
        _authorService = authorService;
    }

    [HttpGet("author")]
    public async Task<ActionResult<List<Book>>> GetListBooks([FromQuery] int id)
    {
        var authorRole = _authorService.FindAuthorRoleById(id);
        if (authorRole.Result == ERole.admin)
        {
            var books = await _bookService.GetListBooks();
            return Ok(books);
        }
        else if (authorRole.Result == ERole.user)
        {
            var books = await _bookService.GetLimitedBooks(id);
            return Ok(books);
        }
        else return BadRequest();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBooks()
    {
        var books = await _bookService.GetListBooks();
        return Ok(books);
    }
}
