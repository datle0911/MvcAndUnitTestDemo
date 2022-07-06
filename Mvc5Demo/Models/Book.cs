namespace Mvc5Demo.Models;

public class Book
{
    public Book(int id, string title, int authorId, List<int> subscriberListById)
    {
        Id = id;
        Title = title;
        AuthorId = authorId;
        SubscriberListById = subscriberListById;
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public int AuthorId { get; set; }
    public List<int> SubscriberListById { get; set; }
}
