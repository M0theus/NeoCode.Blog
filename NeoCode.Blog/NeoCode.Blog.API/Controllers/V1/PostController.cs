using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NeoCode.Blog.API.Utilities;
using NeoCode.Blog.API.ViewModel;
using NeoCode.Blog.API.ViewModel.PostViewModel;
using NeoCode.Blog.Apllication.Contracts.Services;
using NeoCode.Blog.Apllication.DTO.Post;
using NeoCode.Blog.Domain.Contracts.Repositories;

namespace NeoCode.Blog.API.Controllers.V1;

[ApiController]
public class PostController : ControllerBase
{
    private readonly IPostService _postService;
    private readonly IMapper _mapper;
    
    public PostController(IPostService postService, IMapper mapper)
    {
        _postService = postService;
        _mapper = mapper;
    }

    [HttpPost]
    [Route("api/v1/post/create")]
    public async Task<IActionResult> Creat([FromForm] CreatePostViewModel postViewModel)
    {
        try
        {
            var postDto = _mapper.Map<PostDto>(postViewModel);

            var post = await _postService.Create(postDto);

            return Ok(new ResultViewModel
            {
                Message = "Usuário criado com sucesso",
                Success = true,
                Data = post

            });
        }
        catch (Exception ex)
        {
            return BadRequest(Responses.DomainErrorMenssage(ex.Message));
        }
    }
}