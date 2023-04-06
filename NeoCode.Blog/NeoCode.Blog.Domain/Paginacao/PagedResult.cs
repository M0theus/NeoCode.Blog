using NeoCode.Blog.Domain.Contracts.Pagination;

namespace NeoCode.Blog.Domain.Paginacao;

public class PagedResult<T> : IPagedResult<T>
{
    public IList<T> Items { get; set; }
    public IPagination Pagination { get; set; }
    
    public PagedResult()
    {
        Items = new List<T>();
        Pagination = new PaginationInformation();
    }
    
    public PagedResult(int page, int perPage, int total) : this()
    {
        Pagination = new PaginationInformation
        {
            CurrentPage = page,
            PerPage = perPage,
            Total = total
        };
    }
}