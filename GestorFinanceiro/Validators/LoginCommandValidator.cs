using FluentValidation;
using GestorFinanceiro.Commands;

namespace GestorFinanceiro.Validators
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(campo => campo.Email)
              .NotNull().WithMessage("O email não pode estar nulo")
              .NotEmpty().WithMessage("O email não pode estar vazio");

            RuleFor(campo => campo.Senha)
                .NotNull().WithMessage("A senha não pode estar nulo")
                .NotEmpty().WithMessage("A senha email não pode estar vazio");
        }
    }
}
