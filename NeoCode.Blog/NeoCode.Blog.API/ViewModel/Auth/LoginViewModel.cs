using System.ComponentModel.DataAnnotations;

namespace NeoCode.Blog.API.ViewModel.Auth;

public class LoginViewModel
{
    [Required(ErrorMessage = "O nome não pode ser vazio")]
    [EmailAddress]
    public string Email { get; set; } = null!;
    
    [Required(ErrorMessage = "A senha não pode ser vazio")]
    public string Senha { get; set; } = null!;
}