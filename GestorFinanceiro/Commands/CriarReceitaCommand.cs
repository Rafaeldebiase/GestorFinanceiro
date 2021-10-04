using FluentValidation.Results;
using GestorFinanceiro.Validators;
using System;
using System.Collections.Generic;

namespace GestorFinanceiro.Commands
{
    public class CriarReceitaCommand
    {
        public Guid CategoriaId { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public DateTime DataDeRecebimento { get; set; }
        public string Origem { get; set; }

        public bool EhValido()
        {
            var validator = new CriarReceitaCommandValidator();
            return validator.Validate(this).IsValid;
        }

        public List<ValidationFailure> RetornaErros()
        {
            var validator = new CriarReceitaCommandValidator();
            return validator.Validate(this).Errors;
        }

    }
}
