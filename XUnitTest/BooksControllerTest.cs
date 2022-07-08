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
        var authorId = 1;
        var sut = new BooksController(_mockBookService.Object, _mockAuthorService.Object);

        var result = (OkObjectResult)await sut.GetListBooks(authorId);

        Assert.True(result.StatusCode == 200);
    }

    [Fact]
    public async Task GetListBooks_OnSuccess_InvokesBookService()
    {
        // Arrange
        var mockBookService = new Mock<IBookService>();
        var mockAuthorService = new Mock<IAuthorService>();
        var authorId = 1;

        mockBookService
            .Setup(service => service.GetListBooks())
            .ReturnsAsync(new List<Book>());

        var sut = new BooksController(mockBookService.Object, mockAuthorService.Object);

        // Act
        var result = await sut.GetListBooks(authorId);

        // Assert
        mockBookService.Verify(service => service.GetListBooks(), Times.Once());
        //mockBookService.Verify(service => service.GetLimitedBooks(authorId), Times.Once());
    }

    //[Fact]
    //public async Task GetListBooks_OnSuccess_ReturnsListOfBooks()
    //{
    //    // Arrange
    //    var mockBookService = new Mock<IBookService>();
    //    var mockAuthorService = new Mock<IAuthorService>();
    //    var authorId = 1;

    //    mockBookService
    //        .Setup(service => service.GetListBooks())
    //        .ReturnsAsync(new List<Book>());

    //    var sut = new BooksController(mockBookService.Object, mockAuthorService.Object);

    //    // Act
    //    var result = await sut.GetListBooks(authorId);

    //    // Assert
    //    Assert.True(result is IActionResult);
    //    var objectResult = (OkObjectResult)result;
    //    var type = objectResult.Value.GetType();

    //    Assert.NotNull(objectResult);
    //}
}
