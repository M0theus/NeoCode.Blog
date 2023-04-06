using FluentValidation;
using NeoCode.Blog.Domain.Entities;

namespace NeoCode.Blog.Domain.Validation;

public class PostValidator : AbstractValidator<Post>
{
    public PostValidator()
    {
        RuleFor(p => p)
            .NotEmpty()
            .WithMessage("A entidade não pode ser nula")

            .NotNull()
            .WithMessage("A entidade não pode ser nula");

        RuleFor(p => p.Descricao)
            .NotEmpty()
            .WithMessage("A descrição não pode ser vazio")

            .NotNull()
            .WithMessage("A descrição pode ser nulo");

        RuleFor(p => p.Imagem)
            .NotEmpty()
            .NotNull();

        RuleFor(p => p.Titulo)
            .NotEmpty()
            .NotNull();
    }
}