using Microsoft.EntityFrameworkCore;
using NeoCode.Blog.Domain.Contracts.Repositories;
using NeoCode.Blog.Domain.Entities;
using NeoCode.Blog.Infra.Context;

namespace NeoCode.Blog.Infra.Repositories;

public class AdministradorRepository : Repository<Administrador>, IAdministradorRepository
{
    private readonly BlogDbContext _context;
    public AdministradorRepository(BlogDbContext context) : base(context)
    {
        _context = context;
    }
    
    public async Task<Administrador> GetByEmail(string email)
    {
        var adm = await _context.Set<Administrador>()
            .AsNoTracking()
            .Where(a => a.Email.ToLower() == email)
            .ToListAsync();

        return adm.FirstOrDefault();
    }
}