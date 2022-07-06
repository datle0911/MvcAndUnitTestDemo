namespace Mvc5Demo.Models;

public class Author
{
    public Author(int id, string name, ERole role)
    {
        Id = id;
        Name = name;
        Role = role;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public ERole Role { get; set; }
}
