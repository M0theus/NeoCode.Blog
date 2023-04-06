namespace NeoCode.Blog.Domain.Filter;

public class Filter
{
    public string? Description { get; set; }
    public string OrderBy { get; set; } = "description";
    public string OrderDir { get; set; } = "asc";
}