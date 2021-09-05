using Domain.Enums;
using Domain.ObjectValues;
using System;

namespace Domain.Entities
{
    public class Usuário
    {
        public Usuário(
            NomeCompleto nomeCompleto,
            Email email,
            Senha senha,
            string idade,
            Genero genero,
            Endereco endereco
           )
        {
            Id = Guid.NewGuid();
            NomeCompleto = nomeCompleto;
            Email = email;
            Senha = senha;
            Idade = idade;
            Genero = genero;
            Endereco = endereco;
            Ativo = false;
        }

        public Guid Id { get; private set; }
        public NomeCompleto NomeCompleto { get; private set; }
        public Email Email { get; private set; }
        public Senha Senha { get; private set; }
        public string Idade { get; private set; }
        public Genero Genero { get; private set; }
        public Endereco Endereco { get; private set; }
        public bool Ativo { get; private set; }

        public void Ativar()
        {
            Ativo = true;
        }
    }
}
