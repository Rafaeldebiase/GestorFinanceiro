using System;

namespace Domain.ObjectValues
{
    public class Senha
    {
        public Senha(string codigo)
        {
            Codigo = codigo;
        }

        public string Codigo { get; private set; }

        public override bool Equals(object obj)
        {
            return obj is Senha senha &&
                   Codigo == senha.Codigo;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Codigo);
        }
    }
}
