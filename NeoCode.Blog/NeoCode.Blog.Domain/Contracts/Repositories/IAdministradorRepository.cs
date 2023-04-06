using System.Linq.Expressions;
using NeoCode.Blog.Domain.Contracts.Pagination;
using NeoCode.Blog.Domain.Entities;

namespace NeoCode.Blog.Domain.Contracts.Repositories;

public interface IAdministradorRepository : IRepository<Administrador>
{
    /*void Adicionar(Administrador administrador);
    void Atualizar(Administrador administrador);
    void Excluir(Administrador administrador);
    Task<Administrador?> ObterPorId(int id);*/

    Task<Administrador> GetByEmail(string email);
}