using Microsoft.EntityFrameworkCore;
using NeoCode.Blog.Domain.Contracts.Repositories;
using NeoCode.Blog.Domain.Entities;
using NeoCode.Blog.Infra.Context;

namespace NeoCode.Blog.Infra.Repositories;

public class PostRepository : Repository<Post>, IPostRepository
{
    private readonly BlogDbContext _context;
    public PostRepository(BlogDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Post> GetByTitulo(string titulo)
    {
        var post = await _context.Set<Post>()
            .AsNoTracking()
            .Where(p => p.Titulo.ToLower() == titulo)
            .ToListAsync();

        return post.FirstOrDefault();
    }

    public async Task<List<Post>> SearchByTitulo(string titulo)
    {
        var allPost = await _context.Set<Post>()
            .Where(p => p.Titulo.ToLower().Contains(titulo.ToLower()))
            .AsNoTracking()
            .ToListAsync();

        return allPost;
    }
}