using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NeoCode.Blog.Apllication.DTO.Administrador;

public class EditarAdministradorDto
{
    [Display(Name = "id")]
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [Range(1, int.MaxValue, ErrorMessage = "O campo {0} deve possuir o valor mínimo de {1}.")]
    public int Id { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
    
    [Required]
    [PasswordPropertyText]
    public string Senha { get; set; } = null!;
}