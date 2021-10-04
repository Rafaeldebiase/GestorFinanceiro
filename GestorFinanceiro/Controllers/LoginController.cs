using GestorFinanceiro.Commands;
using GestorFinanceiro.ICommandHandle;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace GestorFinanceiro.Controllers
{
    [Route("api/v1/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly ILoginCommandHandle _loginCommandHandle;
        private readonly IConfiguration _configuration;

        public LoginController(ILogger<LoginController> logger, ILoginCommandHandle loginCommandHandle, 
            IConfiguration configuration)
        {
            _logger = logger;
            _loginCommandHandle = loginCommandHandle;
            _configuration = configuration;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody]LoginCommand command)
        {
            try
            {
                if (!command.EhValido())
                {
                    _logger.LogInformation($"{command.RetornaErros()}");
                    return BadRequest(command.RetornaErros());
                }

                var resultado = await _loginCommandHandle.Authenticate(command);

                return Ok(resultado);
            }
            catch (Exception error)
            {
                _logger.LogError($"{error.InnerException} :: {error.Message}");
                throw;
            }
        }

        [HttpGet("logout")]
        [Authorize]
        public void Logout()
        {
            
        }
    }
}
