namespace XUnitTest;

public class BookServiceTest
{
    public readonly BooksController _booksController;
    public readonly Mock<IBookService> _mockBookService;
    public readonly Mock<IAuthorService> _mockAuthorService;
    public readonly DbContext _dbContext;
    public BookServiceTest()
    {
        _dbContext = new DbContext();
        _mockBookService = new Mock<IBookService>();
        _mockAuthorService = new Mock<IAuthorService>();
        _booksController = new BooksController(_mockBookService.Object, _mockAuthorService.Object);
    }


    [Fact]
    public void GetListBook_ReturnAllBooks()
    {
        var result = _mockBookService.Object.GetListBooks().Result;
        int expectedBooks = 4;

        // Assert
        Assert.NotNull(result);
        Assert.True(result == _dbContext.bookList.ToList());
        Assert.True(result.Count == expectedBooks);
    }

    [Fact]
    public void GetLimitedBooks_AdminCall_ReturnAllBooks()
    {
        var result = _mockBookService.Object.GetListBooks().Result;

        // Assert
        Assert.NotNull(result);
        Assert.True(result == _dbContext.bookList.ToList());
        Assert.True(result.Count == 4);
    }

    [Fact]
    public void GetLimitedBooks_UserCall_ReturnLimitedBooks()
    {
        //var authorId = 1;
        var authorId = 5;
        var expectedAmount = 1;
        var result = _mockBookService.Object.GetLimitedBooks(authorId).Result;

        // Assert
        foreach(var book in result)
        {
            Assert.NotNull(book);
            Assert.False(book.AuthorId != authorId && book.SubscriberListById.IndexOf(authorId) != -1);
        }

        Assert.True(result.Count == expectedAmount);
    }
}
