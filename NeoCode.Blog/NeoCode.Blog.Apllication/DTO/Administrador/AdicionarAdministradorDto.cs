using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NeoCode.Blog.Apllication.DTO.Administrador;

public class AdicionarAdministradorDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
    
    [Required]
    [PasswordPropertyText]
    public string Senha { get; set; } = null!;
}