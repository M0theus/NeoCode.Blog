using NeoCode.Blog.Domain.Contracts.Pagination;
using NeoCode.Blog.Domain.Entities;

namespace NeoCode.Blog.Infra.Pagination;

public class PagedResult<T> : IPagedResult<T> where T : Entity, new()
{
    public PagedResult()
    {
        Items = new List<T>();
    }
    
    public List<T> Items { get; set; }
    public int Total { get; set; }
    public int Page { get; set; }
    public int PerPage { get; set; }
    public int PageCount { get; set; }
}