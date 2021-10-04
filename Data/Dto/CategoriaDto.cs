using System;

namespace Data.Dto
{
    public class CategoriaDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Somatorio { get; set; }
    }
}
