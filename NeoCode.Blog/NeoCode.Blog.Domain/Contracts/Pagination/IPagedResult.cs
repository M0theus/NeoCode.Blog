namespace NeoCode.Blog.Domain.Contracts.Pagination;

public interface IPagedResult<T>
{
    public List<T> Items { get; set; }
    public int Total { get; set; }
    public int Page { get; set; }
    public int PerPage { get; set; }
    public int PageCount { get; set; }
}