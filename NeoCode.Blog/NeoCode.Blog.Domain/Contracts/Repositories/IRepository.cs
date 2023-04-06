using System.Linq.Expressions;
using NeoCode.Blog.Domain.Contracts.Pagination;
using NeoCode.Blog.Domain.Entities;

namespace NeoCode.Blog.Domain.Contracts.Repositories;
public interface IRepository<T> : IDisposable where T : Entity
{ 
        /*IUnitOfWork UnitOfWork { get; }
        Task<IPagedResult<T>> Search(int id, Filter.Filter filter, int perPage, int page);*/
        
        Task<T> Create(T obj);
        Task<T> Update(T obj);
        Task<T> Remove(int id);
        Task<T?> GetById(int id);
        Task<List<T>> Get();
}