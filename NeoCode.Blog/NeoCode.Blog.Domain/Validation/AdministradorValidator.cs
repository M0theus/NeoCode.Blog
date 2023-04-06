using FluentValidation;
using NeoCode.Blog.Domain.Entities;

namespace NeoCode.Blog.Domain.Validation;

public class AdministradorValidator : AbstractValidator<Administrador>
{
    public AdministradorValidator()
    {
        RuleFor(a => a.Email)
            .NotEmpty()
            .NotNull()
            .MaximumLength(150)
            .EmailAddress();

        RuleFor(a => a.Senha)
            .NotEmpty()
            .NotNull()
            .MinimumLength(3);
    }
}