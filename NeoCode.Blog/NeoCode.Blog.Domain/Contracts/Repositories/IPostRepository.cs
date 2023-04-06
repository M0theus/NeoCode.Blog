using NeoCode.Blog.Domain.Entities;

namespace NeoCode.Blog.Domain.Contracts.Repositories;

public interface IPostRepository : IRepository<Post>
{
    Task<Post> GetByTitulo(string titulo);
    Task<List<Post>> SearchByTitulo(string titulo);
}