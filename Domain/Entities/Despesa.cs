using System;

namespace Domain.Entities
{
    public class Despesa
    {
        public Despesa(
            decimal valor, 
            Categoria categoria,
            DateTime dataDeCadastro, 
            DateTime dataDaReceita
           )
        {
            Id = Guid.NewGuid();
            Valor = valor;
            Categoria = categoria;
            DataDeCadastro = dataDeCadastro;
            DataDaReceita = dataDaReceita;
        }

        public Guid Id { get; private set; }
        public decimal Valor { get; private set; }
        public Categoria Categoria { get; private set; }
        public DateTime DataDeCadastro { get; private set; }
        public DateTime DataDaReceita { get; private set; }
    }
}
