namespace NeoCode.Blog.Domain.Contracts;

public interface ISoftDelete
{
    public bool Delete { get; set; }
}