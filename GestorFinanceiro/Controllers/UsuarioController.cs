using Data.Interfaces;
using GestorFinanceiro.Commands;
using GestorFinanceiro.ICommandHandle;
using GestorFinanceiro.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace GestorFinanceiro.Controllers
{
    [Route("api/v1/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly IUsuarioRepository _repository;

        public UsuarioController(ILogger<UsuarioController> logger, IUsuarioRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("buscar")]
        public int Buscar(string email)
        {
            return 1;
        }

        [HttpPost("criar")]
        public ActionResult InserirAsync([FromBody]CriarUsuarioCommand command, 
            [FromServices]ICriarUsuarioCommandHandle handle)
        {
            try
            {
                if (!command.EhValido())
                {
                    _logger.LogInformation($"{command.RetornaErros()}");
                    return BadRequest(command.RetornaErros());
                }
                    
                if (_repository.UsuarioExistente(command.Email))
                {
                    _logger.LogInformation($"Usuário com email: {command.Email} já está cadastrado");
                    return BadRequest($"Usuário com email: {command.Email} já está cadastrado");
                }

                handle.CriarCommand(command);

                return Ok();
            }
            catch (Exception error)
            {
                _logger.LogError($"{error.InnerException} :: {error.Message}");
                throw new Exception(error.Message);
            }
            
        }

        [HttpPatch("editar/{email}")]
       public ActionResult Editar([FromBody]EditarUsuarioCommand command, [FromServices]IEditarUsuarioCommandHandle handle)
        {
            try
            {
                if (!command.EhValido())
                {
                    _logger.LogInformation($"{command.RetornaErros()}");
                    return BadRequest(command.RetornaErros());
                }

                if (!_repository.UsuarioExistente(command.Email))
                {
                    _logger.LogInformation($"Usuário com email: {command.Email} não está cadastrado");
                    return BadRequest($"Usuário com email: {command.Email} não está cadastrado");
                }

                handle.EditarCommand(command);

                return Ok();

            }
            catch (Exception error)
            {
                _logger.LogError($"{error.InnerException} :: {error.Message}");
                throw new Exception(error.Message);
            }

                
            
        }
    }
}
