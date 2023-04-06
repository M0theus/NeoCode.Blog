using NeoCode.Blog.Core.Exceptions;
using NeoCode.Blog.Domain.Contracts;
using NeoCode.Blog.Domain.Validation;

namespace NeoCode.Blog.Domain.Entities;

public class Administrador : Entity, IAggregateRoot
{
    public string Email { get; set; } = null!;
    public string Senha { get; set; } = null!;
    //EF
    public virtual List<Post> Posts { get; set; } = new();


    public Administrador()
    {
        
    }
    
    //Provisório
    public Administrador(string email, string senha)
    {
        Email = email;
        Senha = senha;
        _errors = new List<string>();

        Validate();
    }
    public override bool Validate()
    {
        var validator = new AdministradorValidator();
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
    
    public void ChangeEmail(string email)
    {
        Email = email;
        Validate();
    }

    public void ChangePassword(string senha)
    {
        Senha = senha;
        Validate();
    }
}