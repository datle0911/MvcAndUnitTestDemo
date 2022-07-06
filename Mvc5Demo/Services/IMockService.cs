namespace Mvc5Demo.Services;

public interface IMockService
{
    public Task<int> ErrorCode();
    public Task<string> SpecialBlog();
    public Task<string> MockData();

}
