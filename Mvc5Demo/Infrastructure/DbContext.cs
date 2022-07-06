namespace Mvc5Demo.Infrastructure;

public class DbContext
{
    public List<Author> authorList = new()
    {
        new Author(1, "Ander", ERole.admin),
        new Author(2, "Vander", ERole.admin),
        new Author(3, "Herrera", ERole.user),
        new Author(4, "Hector", ERole.user),
        new Author(5, "Milner", ERole.user),
        new Author(6, "Wilnadum", ERole.user),
        new Author(7, "Ronaldo", ERole.user),
        new Author(8, "Messi", ERole.user),
    };

    public List<Book> bookList = new()
    {
        new Book(1, "300 Teenage Codes", 6, new List<int>
        {
            2,3,4,5
        }),

        new Book(2, "Harry Potter", 3, new List<int>
        {
            7,4,6,8
        }),

        new Book(3, "Lord Of the Rings", 3, new List<int>
        {
            1,2,5,7
        }),

        new Book(4, "Tom & Jerry", 4, new List<int>
        {
            2,3,5,7,8
        }),
    };
}
