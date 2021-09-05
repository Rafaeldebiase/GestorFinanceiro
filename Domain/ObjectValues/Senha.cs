namespace Domain.ObjectValues
{
    public class Senha
    {
        public Senha(string codigo)
        {
            Codigo = codigo;
        }

        public string Codigo { get; private set; }
    }
}
