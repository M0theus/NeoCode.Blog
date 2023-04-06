using System.ComponentModel.DataAnnotations;

namespace NeoCode.Blog.API.ViewModel.AdministradorViewModel;

public class CreateAdministradorViewModel
{
    [Required(ErrorMessage = "O Email não pode ser nulo")]
    [MinLength(3, ErrorMessage = "O email deve conter no mínimo 3 caracteres")]
    [MaxLength(150, ErrorMessage = "O email deve ter no máximo 150 caracteres")]
    [EmailAddress]
    public string Email { get; set; } = null!;
    
    [Required(ErrorMessage = "A senha não pode ser nula")]
    [MinLength(3, ErrorMessage = "A senha deve ter no mínimo 3 caracteres")]
    public string Senha { get; set; } = null!;
}