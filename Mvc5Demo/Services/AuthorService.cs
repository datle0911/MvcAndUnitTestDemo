namespace Mvc5Demo.Services;

public class AuthorService : IAuthorService
{
    private readonly DbContext _dbContext;
    public AuthorService(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<ERole> FindAuthorRoleById(int authorId)
    {
        try
        {
            var author = _dbContext
                .authorList
                .FirstOrDefault(a => a.Id == authorId);

            return Task.FromResult(author.Role);
        }

        catch(Exception ex)
        {
            return null;
        }
    }

    public Task<List<Author>> GetAllAuthors()
    {
        var authors = _dbContext
            .authorList
            .ToList();

        return Task.FromResult(authors);
    }
}
