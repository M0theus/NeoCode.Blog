using Microsoft.EntityFrameworkCore;
using NeoCode.Blog.Domain.Contracts.Repositories;
using NeoCode.Blog.Domain.Entities;
using NeoCode.Blog.Infra.Context;

namespace NeoCode.Blog.Infra.Repositories;

public abstract class Repository<T> : IRepository<T> where T : Entity
{
    private readonly BlogDbContext _context;

    public Repository(BlogDbContext context)
    {
        _context = context;
    }
    
    public virtual async Task<T> Create(T obj)
    {
        _context.Add(obj);
        await _context.SaveChangesAsync();

        return obj;
    }

    public virtual async Task<T> Update(T obj)
    {
        _context.Entry(obj).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return obj;
    }

    public virtual async Task<T> Remove(int id)
    {
        var obj = await GetById(id);

        if (obj != null)
        {
            _context.Remove(obj);
            await _context.SaveChangesAsync();
        }

        return obj;
    }

    public virtual async Task<T?> GetById(int id)
    {
        var obj = await _context.Set<T>()
            .AsNoTracking()
            .Where(x => x.Id == id)
            .ToListAsync();

        return obj.FirstOrDefault();
    }

    public virtual async Task<List<T>> Get()
    {
        return await _context.Set<T>()
            .AsNoTracking()
            .ToListAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}