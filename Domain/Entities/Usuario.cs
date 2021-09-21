using Domain.Enums;
using Domain.ObjectValues;
using System;

namespace Domain.Entities
{
    public class Usuario
    {
        public Usuario(
            NomeCompleto nomeCompleto,
            Email email,
            Senha senha,
            DateTime dataNascimento,
            Genero genero,
            Endereco endereco
           )
        {
            Id = Guid.NewGuid();
            NomeCompleto = nomeCompleto;
            Email = email;
            Senha = senha;
            DataNascimento = dataNascimento;
            Genero = genero;
            Endereco = endereco;
            Ativo = false;
        }

        public Guid Id { get; private set; }
        public NomeCompleto NomeCompleto { get; private set; }
        public Email Email { get; private set; }
        public Senha Senha { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public Genero Genero { get; private set; }
        public Endereco Endereco { get; private set; }
        public bool Ativo { get; private set; }

        public void Ativar()
        {
            Ativo = true;
        }

        public void AlteraDataNascimento(DateTime dataNascimento)
        {
            throw new NotImplementedException();
        }

        public void AlterarNome(NomeCompleto nome)
        {
            NomeCompleto = nome;
        }

        public void AlterarEndereco(Endereco end)
        {
            Endereco = end;
        }
    }
}
