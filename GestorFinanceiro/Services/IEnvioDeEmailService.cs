namespace GestorFinanceiro.Services
{
    public interface IEnvioDeEmailService
    {
        bool Enviar(string email, int number, string primeiroNome);
    }
}
