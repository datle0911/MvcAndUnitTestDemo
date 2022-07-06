namespace Mvc5Demo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : Controller
{
    private readonly IBookService _bookService;
    private readonly IAuthorService _authorService;
    private readonly DbContext _dbContext;
    public BooksController(IBookService bookService, IAuthorService authorService, DbContext dbContext)
    {
        _bookService = bookService;
        _authorService = authorService;
        _dbContext = dbContext;
    }

    [HttpGet("author/ID/{authorId}")]
    public async Task<IActionResult> GetListBooks(int authorId)
    {
        var authorRole = _authorService.FindAuthorRoleById(authorId);
        if (authorRole.Result == ERole.admin)
        {
            var books = await _bookService.GetListBooks();
            return Ok(books);
        }
        else if (authorRole.Result == ERole.user)
        {
            var books = await _bookService.GetLimitedBooks(authorId);
            return Ok(books);
        }
        else return BadRequest();
    }

    [HttpGet]
    public async Task<IActionResult> GetListBooks1()
    {
        return Ok(_dbContext.bookList.ToList());
    }
}
