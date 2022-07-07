namespace XUnitTest;

public class AuthorServiceTest
{
    public readonly BooksController _booksController;
    public readonly Mock<IBookService> _mockBookService;
    public readonly Mock<IAuthorService> _mockAuthorService;
    public readonly DbContext _dbContext;
    public AuthorServiceTest()
    {
        _dbContext = new DbContext();
        _mockBookService = new Mock<IBookService>();
        _mockAuthorService = new Mock<IAuthorService>();
        _booksController = new BooksController(_mockBookService.Object, _mockAuthorService.Object);
    }

    [Fact]
    public void FindAuthorRoleById_AdminRole_ReturnTrue()
    {
        var authorId = 1;
        //var authorId = 5;
        var role = _mockAuthorService.Object.FindAuthorRoleById(authorId).Result;

        // Assert
        Assert.True(role == ERole.admin);
        Assert.False(role == ERole.user);

    }

    [Fact]
    public void GetAllAuthors_ReturnTrue()
    {
        //var authorId = 5;
        var role = _mockAuthorService.Object.GetAllAuthors().GetAwaiter().GetResult();

        // Assert
        Assert.True(role.Count == 8);

    }
}
