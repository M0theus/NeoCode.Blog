using NeoCode.Blog.Core.Exceptions;
using NeoCode.Blog.Domain.Validation;

namespace NeoCode.Blog.Domain.Entities;

public class Post : Entity
{
    public string Titulo { get; set; } = null!;
    public string Descricao { get; set; } = null!;
    public Byte[] Imagem { get; set; } = null!;
    public int AdministradorId { get; set; }
    //EF
    public virtual Administrador Administrador { get; set; } = null!;

    public Post()
    {
        
    }
    
    public Post(string titulo, string descricao, byte[] imagem, int administradorId)
    {
        Titulo = titulo;
        Descricao = descricao;
        Imagem = imagem;
        AdministradorId = administradorId;
        _errors = new List<string>();

        Validate();
    }

    public override bool Validate()
    {
        var validator = new PostValidator();
        var validation = validator.Validate(this);

        if (!validation.IsValid)
        {
            foreach (var error in validation.Errors)
            {
                _errors.Add(error.ErrorMessage);

                throw new DomainExceptions("Alguns campos estão inválidos, por favor corrija-os", _errors);
            }
        }

        return true;
    }

    public void ChangeTitulo(string titulo)
    {
        Titulo = titulo;
        Validate();
    }

    public void ChangeDescricao(string descricao)
    {
        Descricao = descricao;
        Validate();
    }

    public void ChangeImagem(Byte[] imagem)
    {
        Imagem = imagem;
        Validate();
    }
}