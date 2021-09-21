using FluentValidation;
using GestorFinanceiro.Commands;

namespace GestorFinanceiro.Validators
{
    public class EditarUsuarioCommandValidator : AbstractValidator<EditarUsuarioCommand>
    {
        public EditarUsuarioCommandValidator()
        {
            RuleFor(campo => campo.PrimeiroNome)
                .NotNull().WithMessage("O primeiro nome não pode estar nulo")
                .NotEmpty().WithMessage("O primeiro nome não pode estar vazio");

            RuleFor(campo => campo.Email)
                .NotNull().WithMessage("O email não pode estar nulo")
                .NotEmpty().WithMessage("O email não pode estar vazio");
        }
    }
}
