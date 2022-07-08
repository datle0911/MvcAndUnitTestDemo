namespace Mvc5Demo.Services;

public class MockService : IMockService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly HttpClient _httpClient;
    public MockService(IHttpClientFactory httpClientFactory, HttpClient httpClient)
    {
        _httpClientFactory = httpClientFactory;
        _httpClient = httpClient;
    }

    public async Task<int> ErrorCode()
    {
        var httpRequestMessage = new HttpRequestMessage(
            HttpMethod.Get,
            "https://api.github.com/");

        var httpClient = _httpClientFactory.CreateClient();
        var httpResponse = await httpClient.SendAsync(httpRequestMessage);

        var end = httpResponse.StatusCode;

        return (int)end;
    }

    public async Task<string> MockData()
    {
        var httpRequestMessage = new HttpRequestMessage(
            HttpMethod.Get,
            "https://deliverywebapi.azurewebsites.net/api/orders?minimal=true");

        var httpClient = _httpClientFactory.CreateClient();
        var httpResponse = await httpClient.SendAsync(httpRequestMessage);

        var end = httpResponse.Content.ReadAsStringAsync();

        return (end.Result + "\n \n              -----------------GET thanh cong va chuyen ve string---------------");
    }

    public async Task<List<Customer>> MockJsonData()
    {
        // return result
        var result = new List<Customer>();

        // http client factory
        var httpRequestMessage = new HttpRequestMessage(
            HttpMethod.Get,
            "https://deliverywebapi.azurewebsites.net/api/customers");

        var httpClient = _httpClientFactory.CreateClient();
        var httpResponse = await httpClient.SendAsync(httpRequestMessage);

        var content = await httpResponse.Content.ReadFromJsonAsync<List<Customer>>();

        // modify content
        content.First().CustomerUserName = "Get bằng IHttpClientFactory nè";

        // duplicate content and add to result
        for (int i = 0; i < 2; i++)
        {
            result.AddRange(content);
        }

        // http client
        var content2 = await _httpClient.GetFromJsonAsync<List<Customer>>("https://deliverywebapi.azurewebsites.net/api/customers");

        // modify content
        content2.First().CustomerFullName = "CÒN ĐÂY LÀ GET BẰNG HTTP CLIENT BTH";

        // duplicate content and add to result
        for (int i = 0; i < 2; i++)
        {
            result.AddRange(content2);
        }

        return result;
    }

    public async Task<string> SpecialBlog()
    {
        await Task.CompletedTask;
        return ("Ngành IT Việt Nam hiện nay ở đầu của sự phát triển. Có thể nói IT là vua của các nghề. Vừa có tiền, có quyền. Vừa kiếm được nhiều $ lại được xã hội trọng vọng.\n Thằng em mình học bách khoa cơ khí, sinh năm 96.Tự mày mò học code rồi đi làm remote cho công ty Mỹ 2 năm nay. Mỗi tối online 3 - 4 giờ là xong việc. Lương tháng 3k6.Nhưng thu nhập chính vẫn là từ nhận các project bên ngoài làm thêm. Tuần làm 2,3 cái nhẹ nhàng 9,10k tiền tươi thóc thật không phải đóng thuế.Làm gần được 3 năm mà nhà xe nó đã mua đủ cả.Nghĩ mà thèm.");
    }
}
