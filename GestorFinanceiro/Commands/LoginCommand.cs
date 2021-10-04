using FluentValidation.Results;
using GestorFinanceiro.Validators;
using System.Collections.Generic;

namespace GestorFinanceiro.Commands
{
    public class LoginCommand
    {
        public string Email { get; set; }
        public string Senha { get; set; }

        public bool EhValido()
        {
            var validator = new LoginCommandValidator();
            return validator.Validate(this).IsValid;
        }

        public List<ValidationFailure> RetornaErros()
        {
            var validator = new LoginCommandValidator();
            return validator.Validate(this).Errors;
        }
    }
}
