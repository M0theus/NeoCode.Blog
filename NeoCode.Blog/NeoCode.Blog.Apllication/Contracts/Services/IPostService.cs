using NeoCode.Blog.Apllication.DTO.Post;

namespace NeoCode.Blog.Apllication.Contracts.Services;

public interface IPostService
{
    Task<PostDto> Create(PostDto postDto);
    Task<PostDto> Update(PostDto postDto);
    Task Remove(int id);
    Task<PostDto> Get(int id);
    Task<List<PostDto>> Get();
    Task<PostDto> GetByTitulo(string name);
    Task<List<PostDto>> SearchByTitulo(string name);    
}