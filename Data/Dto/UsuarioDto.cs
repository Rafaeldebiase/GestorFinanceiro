using Domain.Enums;
using System;

namespace Data.Dto
{
    public class UsuarioDto
    {
        public Guid Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Genero { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string Cep { get; set; }
        public string Funcao { get; set; }
        public bool Ativo { get; set; }
        public int CodigoDeAtivacao { get; set; }
    }
}
