using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NeoCode.Blog.API.Utilities;
using NeoCode.Blog.API.ViewModel;
using NeoCode.Blog.API.ViewModel.Auth;
using NeoCode.Blog.Apllication.Contracts.Services;
using NeoCode.Blog.Apllication.DTO.Auth;
using NeoCode.Blog.Core.Exceptions;

namespace NeoCode.Blog.API.Controllers.V1;

public class AuthController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IAdministradorService _administradorService;
    
    public AuthController(IMapper mapper, IAdministradorService administradorService)
    {
        _mapper = mapper;
        _administradorService = administradorService;
    }

    [HttpPost]
    [Route("api/v1/auth/login")]
    public async Task<IActionResult> Login([FromBody] LoginViewModel loginViewModel)
    {
        try
        {
            var user = _mapper.Map<LoginDto>(loginViewModel);

            var token = await _administradorService.Authenticade(user);

            return Ok(new ResultViewModel
            {
                Message = "Token gerado com sucesso",
                Success = true,
                Data = token
            });
        }
        catch (DomainExceptions exceptions)
        {
            return BadRequest(Responses.DomainErrorMenssage(exceptions.Message));
        }
        catch (Exception)
        {
            return StatusCode(401, Responses.ApplicartionErrorMensage());
        }
    }
}