using Data.Dto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorFinanceiro.Dto
{
    public class LoginDto
    {
        public LoginDto(UsuarioDto usuario, string token)
        {
            Usuario = usuario;
            Token = token;
        }

        protected LoginDto()
        {

        }

        public UsuarioDto Usuario { get; private set; }
        public string Token { get; private set; }
        public string Error { get; private set; }

        public void IncluirToken(string token)
        {
            Token = token;
        }

        public static class LoginDtoFactory
        {
            public static LoginDto IncluirErro(string mensagem)
            {
                var login = new LoginDto
                {
                    Error = mensagem
                };

                return login;
            }
        }
    }
}
