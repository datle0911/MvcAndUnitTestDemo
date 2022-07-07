using Microsoft.AspNetCore.Mvc;

namespace XUnitTest;

public class BooksControllerTest
{
    public readonly BooksController _booksController;
    public readonly Mock<IBookService> _mockBookService;
    public readonly Mock<IAuthorService> _mockAuthorService;
    public readonly DbContext _dbContext;
    public BooksControllerTest()
    {
        _dbContext = new DbContext();
        _mockBookService = new Mock<IBookService>();
        _mockAuthorService = new Mock<IAuthorService>();
        _booksController = new BooksController(_mockBookService.Object, _mockAuthorService.Object);
    }

    [Fact]
    public async Task GetAlBooks_OnSuccess_ReturnsStatusCode200()
    {
        var sut = new BooksController(_mockBookService.Object, _mockAuthorService.Object);

        var result = (OkObjectResult)await sut.GetAllBooks();

        Assert.True(result.StatusCode == 200);
    }

    [Fact]
    public async Task GetListBooks_OnSuccess_ReturnsStatusCode200()
    {
        var sut = new BooksController(_mockBookService.Object, _mockAuthorService.Object);

        var result = (OkObjectResult)await sut.GetListBooks(1);

        Assert.True(result.StatusCode == 200);
    }
}
