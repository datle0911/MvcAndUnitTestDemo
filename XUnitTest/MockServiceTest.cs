using Microsoft.AspNetCore.Mvc;

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

    [Fact]
    public async Task OnMockJsonData_OnSuccess_ReturnsStatusCode200()
    {
        var result = (OkObjectResult)await _mockController.HttpClientGetJsonObjects();

        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
    }

    [Fact]
    public async Task Service_OnMockJsonData_OnSuccess_ReturnsCustomersList()
    {
        var sut = new Mock<MockService>();
        var result = await sut.Object.MockJsonData();

        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
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