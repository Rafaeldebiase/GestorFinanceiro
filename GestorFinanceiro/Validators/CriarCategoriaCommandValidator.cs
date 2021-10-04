using FluentValidation;
using GestorFinanceiro.Commands;

namespace GestorFinanceiro.Validators
{
    public class CriarCategoriaCommandValidator : AbstractValidator<CriarCategoriaCommand>
    {
        public CriarCategoriaCommandValidator()
        {
            RuleFor(campo => campo.Nome)
                .NotNull().WithMessage("O nome da categoria não pode estar nulo")
                .NotEmpty().WithMessage("O nome da categoria não pode estar vazio");
        }
    }
}
