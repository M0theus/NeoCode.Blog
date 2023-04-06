using Microsoft.EntityFrameworkCore;
using NeoCode.Blog.Domain.Contracts;
using NeoCode.Blog.Domain.Entities;
using NeoCode.Blog.Infra.Mappings;

namespace NeoCode.Blog.Infra.Context;

public class BlogDbContext : DbContext, IUnitOfWork
{
    public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
    {}

    public DbSet<Administrador> Administradores { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new AdministradorMapping());
        builder.ApplyConfiguration(new PostMapping());
    }

    public async Task<bool> Commit() => await SaveChangesAsync() > 0;
}