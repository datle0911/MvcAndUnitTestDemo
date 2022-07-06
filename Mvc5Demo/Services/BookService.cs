using System.Linq;

namespace Mvc5Demo.Services;

public class BookService : IBookService
{
    private readonly DbContext _dbContext;
    public BookService(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<Book>> GetLimitedBooks(int authorId)
    {
        var resource = new List<Book>();
        var bookList = _dbContext.bookList.ToList();
        foreach (var book in bookList)
        {
            if(book.AuthorId == authorId)
            {
                resource.Add(book);
            }

            if (book.SubscriberListById.IndexOf(authorId) != -1)
            {
                resource.Add(book);
            }
        }

        return Task.FromResult(resource);
    }

    public Task<List<Book>> GetListBooks()
    {
        var booksList = _dbContext.bookList.ToList();
        return Task.FromResult(booksList);
    }
}
