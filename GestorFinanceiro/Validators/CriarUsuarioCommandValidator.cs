using FluentValidation;
using GestorFinanceiro.Commands;

namespace GestorFinanceiro.Validators
{
    public class CriarUsuarioCommandValidator : AbstractValidator<CriarUsuarioCommand>
    {
        public CriarUsuarioCommandValidator()
        {
            RuleFor(campo => campo.PrimeiroNome)
                .NotNull().WithMessage("O primeiro nome não pode estar nulo")
                .NotEmpty().WithMessage("O primeiro nome não pode estar vazio");

            RuleFor(campo => campo.Email)
                .NotNull().WithMessage("O email não pode estar nulo")
                .NotEmpty().WithMessage("O email não pode estar vazio");

            RuleFor(campo => campo.Senha)
                .NotNull().WithMessage("A senha não pode estar nulo")
                .NotEmpty().WithMessage("A senha email não pode estar vazio");
        }
    }
}
