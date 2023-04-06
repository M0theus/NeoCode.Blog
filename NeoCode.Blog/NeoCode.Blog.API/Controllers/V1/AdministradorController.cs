using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NeoCode.Blog.API.Utilities;
using NeoCode.Blog.API.ViewModel;
using NeoCode.Blog.API.ViewModel.AdministradorViewModel;
using NeoCode.Blog.Apllication.Contracts.Services;
using NeoCode.Blog.Apllication.DTO.Administrador;
using NeoCode.Blog.Core.Exceptions;

namespace NeoCode.Blog.API.Controllers.V1;

public class AdministradorController : ControllerBase
{
    private readonly IAdministradorService _administradorService;
    private readonly IMapper _mapper;
    
    public AdministradorController(IAdministradorService administradorService, IMapper mapper)
    {
        _administradorService = administradorService;
        _mapper = mapper;
    }
    
    [HttpPost]
    [Route("/api/v1/adm/adicionar")]
    public async Task<IActionResult> Adicionar([FromBody]CreateAdministradorViewModel administradorViewModel)
    {
        try
        {
            var admDto = _mapper.Map<AdministradorDto>(administradorViewModel);

            var admCreated = await _administradorService.Adicionar(admDto);

            return Ok(new ResultViewModel
            {
                Message = "Administrador criado com sucesso",
                Success = true,
                Data = admCreated

            });
        }
        catch (DomainExceptions ex)
        {
            return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
        }
        catch(Exception)
        {
            return StatusCode(500, Responses.ApplicartionErrorMensage());
        }
    }
    
    [HttpDelete]
    [Route("ap1/v1/adm/Excluir{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _administradorService.Excluir(id);

            return Ok(new ResultViewModel
            {
                Message = "Administrador removido com sucesso",
                Success = true,
                Data = null
            });
        }
        catch (Exception ex)
        {
            return BadRequest(Responses.DomainErrorMenssage(ex.Message));
        }
    }
}