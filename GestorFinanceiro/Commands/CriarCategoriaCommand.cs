using FluentValidation.Results;
using GestorFinanceiro.Validators;
using System.Collections.Generic;

namespace GestorFinanceiro.Commands
{
    public class CriarCategoriaCommand
    {
        public string Nome { get; set; }
        public string Categoria { get; set; }

        public bool EhValido()
        {
            var validator = new CriarCategoriaCommandValidator();
            return validator.Validate(this).IsValid;
        }

        public List<ValidationFailure> RetornaErros()
        {
            var validator = new CriarCategoriaCommandValidator();
            return validator.Validate(this).Errors;
        }
    }
}
