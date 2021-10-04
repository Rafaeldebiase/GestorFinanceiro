using FluentValidation.Results;
using GestorFinanceiro.Validators;
using System;
using System.Collections.Generic;

namespace GestorFinanceiro.Commands
{
    public class EditarCategoriaCommand
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public bool EhValido()
        {
            var validator = new EditarCategoriaCommandValidation();
            return validator.Validate(this).IsValid;
        }

        public List<ValidationFailure> RetornaErros()
        {
            var validator = new EditarCategoriaCommandValidation();
            return validator.Validate(this).Errors;
        }
    }
}
