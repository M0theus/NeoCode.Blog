using AutoMapper;
using NeoCode.Blog.Apllication.Contracts.Services;
using NeoCode.Blog.Apllication.DTO.Post;
using NeoCode.Blog.Core.Exceptions;
using NeoCode.Blog.Domain.Contracts.Repositories;
using NeoCode.Blog.Domain.Entities;

namespace NeoCode.Blog.Apllication.Services;

public class PostService : IPostService
{
    private readonly IMapper _mapper;
    private readonly IPostRepository _postRepository;
    
    public PostService(IMapper mapper, IPostRepository postRepository)
    {
        _mapper = mapper;
        _postRepository = postRepository;
    }
    
    public async Task<PostDto> Create(PostDto postDto)
    {
        var postExists = await _postRepository.GetByTitulo(postDto.Titulo);

        if (postExists != null)
        {
            throw new DomainExceptions("Já existe um Post com esse nome");
        }
        
        var post = _mapper.Map<Post>(postDto);
        
        
        var memoryStream = new MemoryStream();
        await postDto.Foto.CopyToAsync(memoryStream);

        if (memoryStream.Length < 2097152)
        {
            post.Imagem = memoryStream.ToArray();
        }
        else
        {
            throw new DomainExceptions("O arquivo da imagem é muito grande");
        }
        
        post.Validate();

        var postCreate = await _postRepository.Create(post);

        return _mapper.Map<PostDto>(postCreate);
    }

    public Task<PostDto> Update(PostDto postDto)
    {
        throw new NotImplementedException();
    }

    public Task Remove(int id)
    {
        throw new NotImplementedException();
    }

    public Task<PostDto> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<PostDto>> Get()
    {
        throw new NotImplementedException();
    }

    public Task<PostDto> GetByTitulo(string name)
    {
        throw new NotImplementedException();
    }

    public Task<List<PostDto>> SearchByTitulo(string name)
    {
        throw new NotImplementedException();
    }
}