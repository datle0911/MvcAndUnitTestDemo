namespace Mvc5Demo.Services;

public interface IBookService
{
    public Task<List<Book>> GetListBooks();
    public Task<List<Book>> GetLimitedBooks(int authorId);
}
