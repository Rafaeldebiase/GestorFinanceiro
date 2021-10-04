using FluentValidation;
using GestorFinanceiro.Commands;

namespace GestorFinanceiro.Validators
{
    public class CriarReceitaCommandValidator : AbstractValidator<CriarReceitaCommand>
    {
        public CriarReceitaCommandValidator()
        {
            RuleFor(campo => campo.CategoriaId)
                .NotNull().WithMessage("O id da categoria não pode estar nulo")
                .NotEmpty().WithMessage("O id da categoria não pode estar vazio");

            RuleFor(campo => campo.Valor)
                .NotNull().WithMessage("O valor da receita não pode estar nulo")
                .NotEmpty().WithMessage("O valor da receita não pode estar vazio");

            RuleFor(campo => campo.Origem)
                .NotNull().WithMessage("A origem da receita não pode estar nulo")
                .NotEmpty().WithMessage("A origem da receita não pode estar vazio");
        }
    }
}
