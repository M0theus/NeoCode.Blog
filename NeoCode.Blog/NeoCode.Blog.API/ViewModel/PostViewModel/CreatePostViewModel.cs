using System.ComponentModel.DataAnnotations;

namespace NeoCode.Blog.API.ViewModel.PostViewModel;

public class CreatePostViewModel
{
    [Required(ErrorMessage = "Titulo não pode ser vazio")]
    public string Titulo { get; set; } = null!;
    
    [Required(ErrorMessage = "Descrição não pode ser vazio")]
    public string Descricao { get; set; } = null!;
    
    [Required(ErrorMessage = "A imagem não pode ser vazio")]
    public IFormFile Imagem { get; set; } = null!;
    
    [Required(ErrorMessage = "O admId não pode ser vazio")]
    public int AdministradorId { get; set; }
}