namespace NeoCode.Blog.Domain.Contracts;

public interface IUnitOfWork
{
    Task<bool> Commit();
}