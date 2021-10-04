using FluentValidation;
using GestorFinanceiro.Commands;

namespace GestorFinanceiro.Validators
{
    public class EditarCategoriaCommandValidation : AbstractValidator<EditarCategoriaCommand>
    {
        public EditarCategoriaCommandValidation()
        {
            RuleFor(campo => campo.Id)
               .NotNull().WithMessage("O id da categoria não pode estar nulo")
               .NotEmpty().WithMessage("O id da categoria não pode estar vazio");

            RuleFor(campo => campo.Nome)
               .NotNull().WithMessage("O nome da categoria não pode estar nulo")
               .NotEmpty().WithMessage("O nome da categoria não pode estar vazio");
        }
    }
}
