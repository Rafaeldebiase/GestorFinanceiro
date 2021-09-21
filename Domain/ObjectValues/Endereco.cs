using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ObjectValues
{
    public class Endereco
    {
        public Endereco(
            string logradouro,
            int numero, 
            string complemento,
            string bairro,
            string cidade, 
            string estado, 
            string pais,
            string cep
            )
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
            Cep = cep;
        }

        public string Logradouro { get; private set; }
        public int Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Pais { get; private set; }
        public string Cep { get; private set; }

        public override bool Equals(object obj)
        {
            return obj is Endereco endereco &&
                   Logradouro == endereco.Logradouro &&
                   Numero == endereco.Numero &&
                   Complemento == endereco.Complemento &&
                   Bairro == endereco.Bairro &&
                   Cidade == endereco.Cidade &&
                   Estado == endereco.Estado &&
                   Pais == endereco.Pais &&
                   Cep == endereco.Cep;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Logradouro, Numero, Complemento, Bairro, Cidade, Estado, Pais, Cep);
        }
    }
}
