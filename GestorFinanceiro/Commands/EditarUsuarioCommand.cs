]using FluentValidation.Results;
using GestorFinanceiro.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorFinanceiro.Commands
{
    public class EditarUsuarioCommand
    {
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Genero { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string Cep { get; set; }

        public bool EhValido()
        {
            var validator = new EditarUsuarioCommandValidator();
            return validator.Validate(this).IsValid;
        }

        public List<ValidationFailure> RetornaErros()
        {
            var validator = new EditarUsuarioCommandValidator();
            return validator.Validate(this).Errors;
        }
    }
}
