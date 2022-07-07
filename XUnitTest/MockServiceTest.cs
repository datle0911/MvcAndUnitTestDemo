namespace XUnitTest;
public class MockServiceTest
{
    private readonly MockController _mockController; 
    private readonly Mock<IMockService> _mockService;
    public MockServiceTest()
    {
        _mockService = new Mock<IMockService>();
        _mockController = new MockController(_mockService.Object);
    }

    [FactAttribute]
    public async Task MockDataTest()
    {
        var result = await _mockController.MockData().ConfigureAwait(true);

        Assert.NotNull(result);
    }

    [FactAttribute]
    public async Task SpecialBlogTest()
    {
        var result = await _mockController.SpecialBlog().ConfigureAwait(true);

        Assert.NotNull(result);
    }

    [FactAttribute]
    public async Task ErrorCodeTest()
    {
        var result = await _mockController.ErrorCode().ConfigureAwait(true);

        Assert.NotNull(result);
    }
}