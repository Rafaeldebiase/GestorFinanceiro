using System;

namespace GestorFinanceiro.Services
{
    public class GeradorDeCodigo
    {
        public int Generator()
        {
            var number = new Random();
            return number.Next();
        }
    }
}
