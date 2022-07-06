namespace Mvc5Demo.Services;

public interface IAuthorService
{
    public Task<ERole> FindAuthorRoleById(int authorId);
    public Task<List<Author>> GetAllAuthors();
}
