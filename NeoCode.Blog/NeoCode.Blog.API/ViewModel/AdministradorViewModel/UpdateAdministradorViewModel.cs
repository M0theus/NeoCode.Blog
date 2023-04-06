using System.ComponentModel.DataAnnotations;

namespace NeoCode.Blog.API.ViewModel.AdministradorViewModel;

public class UpdateAdministradorViewModel
{
    [Required(ErrorMessage = "O Id não pode ser vazio.")]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O Email não pode ser nulo")]
    [MinLength(3, ErrorMessage = "O email deve conter no mínimo 3 caracteres")]
    [MaxLength(150, ErrorMessage = "O email deve ter no máximo 255 caracteres")]
    [EmailAddress]
    public string Email { get; set; } = null!;
    
    [Required(ErrorMessage = "A senha não pode ser nula")]
    [MinLength(3, ErrorMessage = "A senha deve ter no mínimo 3 caracteres")]
    public string Senha { get; set; } = null!;
}