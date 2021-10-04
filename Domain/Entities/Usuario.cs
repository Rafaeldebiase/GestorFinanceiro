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
            DateTime? dataNascimento,
            Genero? genero,
            Endereco endereco)
        {
            Id = Guid.NewGuid();
            NomeCompleto = nomeCompleto;
            Email = email;
            Senha = senha;
            DataNascimento = dataNascimento;
            Genero = genero;
            Endereco = endereco;
            Ativo = false;
            Funcao = Funcao.USUARIO;
        }

        public Usuario(
            Guid id, 
            NomeCompleto nomeCompleto, 
            Email email, 
            DateTime? dataNascimento, 
            Genero? genero, 
            Endereco endereco)
        {
            Id = id;
            NomeCompleto = nomeCompleto;
            Email = email;
            DataNascimento = dataNascimento;
            Genero = genero;
            Endereco = endereco;
        }

        public Guid Id { get; private set; }
        public NomeCompleto NomeCompleto { get; private set; }
        public Email Email { get; private set; }
        public Senha Senha { get; private set; }
        public DateTime? DataNascimento { get; private set; }
        public Genero? Genero { get; private set; }
        public Endereco Endereco { get; private set; }
        public bool Ativo { get; private set; }
        public int CodigoDeAtivacao { get; private set; }
        public Funcao Funcao { get; set; }

        public void InserirCodigoDeAtivacao(int codigo)
        {
            CodigoDeAtivacao = codigo;
        }

        public void AlterarSenha(string senha)
        {
            Senha = new Senha(senha);
        }

        public void AlterarFuncao(Funcao funcao)
        {
            Funcao = funcao;
        }

        public void AlterarGenero(Genero genero)
        {
            Genero = genero;
        }

        public void Ativar()
        {
            Ativo = true;
        }

        public void AlterarDataNascimento(DateTime? dataNascimento)
        {
            DataNascimento = dataNascimento;
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
