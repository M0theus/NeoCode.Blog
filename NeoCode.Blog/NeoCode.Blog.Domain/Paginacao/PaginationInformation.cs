using NeoCode.Blog.Domain.Contracts.Pagination;

namespace NeoCode.Blog.Domain.Paginacao;
public class PaginationInformation : IPagination
{
    public int Total { get; set; }
    public int TotalInPage { get; set; }
    public int CurrentPage { get; set; }
    public int PerPage { get; set; }
    public int PageCount { get; set; }
}