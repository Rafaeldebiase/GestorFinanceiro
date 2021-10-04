using Data.Interfaces;
using GestorFinanceiro.Commands;
using GestorFinanceiro.Dto;
using GestorFinanceiro.ICommandHandle;
using GestorFinanceiro.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GestorFinanceiro.CommandHandle
{
    public class LoginCommandHandle : ILoginCommandHandle
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILogger<LoginCommandHandle> _logger;
        private readonly IConfiguration _configuration;

        public LoginCommandHandle(IUsuarioRepository usuarioRepository, ILogger<LoginCommandHandle> logger, IConfiguration configuration)
        {
            _usuarioRepository = usuarioRepository;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<LoginDto> Authenticate(LoginCommand command)
        {
            var usuarioDto = await _usuarioRepository.Autenticar(command.Email, command.Senha);

            if (usuarioDto == null)
                return LoginDto.LoginDtoFactory.IncluirErro("Usuário não cadastrado ou senha inválida");

            if (!usuarioDto.Ativo)
                return LoginDto.LoginDtoFactory.IncluirErro("O usuário não está ativo");

            var secret = _configuration.GetValue<string>("SecretKey");
            var token = TokenService.GenerateToken(usuarioDto, secret);

            
            return new LoginDto(usuarioDto, token);
        }

        public void Logout()
        {
            throw new System.NotImplementedException();
        }
    }
}
