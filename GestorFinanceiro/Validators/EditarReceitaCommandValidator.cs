using FluentValidation;
using GestorFinanceiro.Commands;

namespace GestorFinanceiro.Validators
{
    public class EditarReceitaCommandValidator : AbstractValidator<EditarReceitaCommand>
    {
        public EditarReceitaCommandValidator()
        {
            RuleFor(campo => campo.CategoriaId)
                .NotNull().WithMessage("O id da categoria não pode estar nulo")
                .NotEmpty().WithMessage("O id da categoria não pode estar vazio");
            
            RuleFor(campo => campo.Id)
                .NotNull().WithMessage("O id não pode estar nulo")
                .NotEmpty().WithMessage("O id não pode estar vazio");
        }
    }
}
