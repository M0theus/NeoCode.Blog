namespace NeoCode.Blog.Domain.Contracts.Pagination;

public interface IPagination
{
    public int Total { get; set; }
    public int TotalInPage { get; set; }
    public int CurrentPage { get; set; }
    public int PerPage { get; set; }
    public int PageCount { get; set; }
}