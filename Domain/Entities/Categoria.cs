using System;

namespace Domain.Entities
{
    public class Categoria
    {
        public Categoria(string nome, string descricao)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Descricao = descricao;
        }

        public Categoria(Guid id, string nome, string descricao)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
        }

        public Categoria(Guid id, string nome, string descricao, decimal somatorio)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Somatorio = somatorio;
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Somatorio { get; private set; }

        public void Calcular(decimal valor)
        {
            Somatorio += valor;
        }
    }
}
