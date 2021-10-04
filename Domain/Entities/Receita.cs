using System;

namespace Domain.Entities
{
    public class Receita
    {
        public Receita(
            decimal valor,
            Guid categoriaId,
            DateTime dataDaReceita,
            string origem, 
            string descricao)
        {
            Id = Guid.NewGuid();
            Valor = valor;
            CategoriaId = categoriaId;
            DataDeCadastro = DateTime.Now;
            DataDaReceita = dataDaReceita;
            Origem = origem;
            Descricao = descricao;
        }

        public Guid Id { get; private set; }
        public decimal Valor { get; private set; }
        public Guid CategoriaId { get; private set; }
        public DateTime DataDeCadastro { get; private set; }
        public DateTime DataDaReceita { get; private set; }
        public string Origem { get; set; }
        public string Descricao { get; set; }
    }
}
