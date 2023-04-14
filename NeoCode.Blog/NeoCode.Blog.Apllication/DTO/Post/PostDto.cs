using Microsoft.AspNetCore.Http;

namespace NeoCode.Blog.Apllication.DTO.Post;

public class PostDto
{
    public int Id { get; set; }
    public string Titulo { get; set; } = null!;
    public string Descricao { get; set; } = null!;
    public IFormFile Foto { get; set; } = null!;
    public int AdministradorId { get; set; }

    public PostDto()
    {
        
    }
    
    public PostDto(string titulo, string descricao, IFormFile imagem, int administradorId, int id)
    {
        Id = id;
        Titulo = titulo;
        Descricao = descricao;
        Foto = imagem;
        AdministradorId = administradorId;
    }
}