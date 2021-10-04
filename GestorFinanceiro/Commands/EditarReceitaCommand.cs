using FluentValidation.Results;
using GestorFinanceiro.Validators;
using System;
using System.Collections.Generic;

namespace GestorFinanceiro.Commands
{
    public class EditarReceitaCommand
    {
        public Guid Id { get; set; }
        public decimal Valor { get; set; }
        public Guid CategoriaId { get; set; }
        public DateTime DataDaReceita { get; set; }
        public string Origem { get; set; }
        public string Descricao { get; set; }

        public bool EhValido()
        {
            var validator = new EditarReceitaCommandValidator();
            return validator.Validate(this).IsValid;
        }

        public List<ValidationFailure> RetornaErros()
        {
            var validator = new EditarReceitaCommandValidator();
            return validator.Validate(this).Errors;
        }
    }
}
