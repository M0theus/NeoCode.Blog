using System.Linq.Expressions;

namespace NeoCode.Blog.Domain.Contracts.Pagination;

public interface IPaginedSearch<T> where T : IEntity
{
    public int Page { get; set; }
    public int PerPage { get; set; }
    public string SortBy { get; set; }
    public string SortDir { get; set; }

    public void ApplyFilter(ref IQueryable<T> query);
    public void ApplyOrdernation(ref IQueryable<T> query);
    public Expression<Func<T, bool>> BuildExpression();
}