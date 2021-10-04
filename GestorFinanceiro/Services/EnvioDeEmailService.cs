using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace GestorFinanceiro.Services
{
    public class EnvioDeEmailService : IEnvioDeEmailService
    {
        private readonly ILogger<EnvioDeEmailService> _logger;

        public EnvioDeEmailService(ILogger<EnvioDeEmailService> logger)
        {
            _logger = logger;
        }

        public bool Enviar(string email, int codigo, string primeiroNome)
        {
            try
            {
                using (var _mailMessage = new MailMessage())
                {
                    _mailMessage.From = new MailAddress("evolutiondraft@gmail.com");
                    _mailMessage.To.Add(email);
                    _mailMessage.Subject = "Email de ativação";
                    _mailMessage.IsBodyHtml = true;
                    _mailMessage.Body = $"{CriarEmail(codigo, primeiroNome)}";

                    SmtpClient _smtpClient = new SmtpClient("smtp.gmail.com", Convert.ToInt32("587"));

                    _smtpClient.UseDefaultCredentials = false;
                    _smtpClient.Credentials = new NetworkCredential("meugerenciadorfinanceiro@gmail.com", "$Jonny&Ruthy01%");

                    _smtpClient.EnableSsl = true;

                    _smtpClient.Send(_mailMessage);

                    return true;
                }
            }
            catch (Exception error)
            {
                _logger.LogError($"{error.InnerException} :: {error.Message}");
                throw;
            }
        }

        private string CriarEmail(int number, string primeiroNome)
        {
            var email = new StringBuilder();
            email.Append($"<p>Olá, <strong>{primeiroNome}</strong>,");
            email.Append("seja bem vindo ao Gestor Financeiro!<br>");
            email.Append("<p>Forneça este código para ativação do seu cadastro.</p>");
            email.Append($"<span>{number}</span>");

            return email.ToString();

        }
    }
}
