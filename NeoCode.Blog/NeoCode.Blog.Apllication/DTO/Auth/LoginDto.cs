using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NeoCode.Blog.Apllication.DTO.Auth;

public class LoginDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
    
    [Required]
    [PasswordPropertyText]
    public string Password { get; set; } = null!;

}