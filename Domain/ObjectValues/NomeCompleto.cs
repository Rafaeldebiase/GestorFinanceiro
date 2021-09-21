using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ObjectValues
{
    public class NomeCompleto
    {
        public NomeCompleto(string primeiroNome, string ultimoNome)
        {
            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;
        }

        public string PrimeiroNome { get; private set; }
        public string UltimoNome { get; private set; }

        public override bool Equals(object obj)
        {
            return obj is NomeCompleto completo &&
                   PrimeiroNome == completo.PrimeiroNome &&
                   UltimoNome == completo.UltimoNome;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(PrimeiroNome, UltimoNome);
        }

        public override string ToString()
        {
            return $"{PrimeiroNome} {UltimoNome}";
        }
    }
}
