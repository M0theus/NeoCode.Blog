using NeoCode.Blog.Apllication.DTO.Administrador;
using NeoCode.Blog.Apllication.DTO.Auth;

namespace NeoCode.Blog.Apllication.Contracts.Services;

public interface IAdministradorService
{
    Task<AdministradorDto> ObterPorId(int id);
    Task<AdministradorDto> Adicionar(AdministradorDto administradorDto);
    Task<AdministradorDto> Editar(AdministradorDto administradorDto);
    Task Excluir(int id);
    Task<AuthenticateAdministradorDto> Authenticade(LoginDto loginDto);
}