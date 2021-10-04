using Data.Dto;
using Data.Interfaces;
using GestorFinanceiro.Commands;
using GestorFinanceiro.ICommandHandle;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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

        [HttpGet]
        [Authorize(Roles = "ADMINISTRADOR")]
        public async Task<IEnumerable<UsuarioDto>> BuscarTodos()
        {
            return await _repository.BuscarTodos();
        }

        [HttpPost("criar")]
        [AllowAnonymous]
        public async Task<ActionResult> InserirAsync([FromBody]CriarUsuarioCommand command, 
            [FromServices]ICriarUsuarioCommandHandle handle)
        {
            try
            {
                if (!command.EhValido())
                {
                    _logger.LogInformation($"{command.RetornaErros()}");
                    return BadRequest(command.RetornaErros());
                }
                    
                if (await _repository.UsuarioExistente(command.Email))
                {
                    _logger.LogInformation($"Usuário com email: {command.Email} já está cadastrado");
                    return BadRequest($"Usuário com email: {command.Email} já está cadastrado");
                }

                var resultado = await handle.Criar(command);

                return resultado == true ? 
                    StatusCode(201) : 
                    BadRequest($"Não foi possível criar o usuário");
                
            }
            catch (Exception error)
            {
                _logger.LogError($"{error.InnerException} :: {error.Message}");
                throw new Exception(error.Message);
            }
            
        }

       [HttpPatch("editar")]
       [Authorize]
        public async Task<ActionResult> Editar([FromBody]EditarUsuarioCommand command, [FromServices]IEditarUsuarioCommandHandle handle)
        {
            try
            {
                if (!command.EhValido())
                {
                    _logger.LogInformation($"{command.RetornaErros()}");
                    return BadRequest(command.RetornaErros());
                }

                var id = User.Identity.Name;

                var retorno = await handle.EditarCommand(command, id);

                if(retorno) return Ok();

                return BadRequest();

            }
            catch (Exception error)
            {
                _logger.LogError($"{error.InnerException} :: {error.Message}");
                throw new Exception(error.Message);
            }
        }

        [HttpDelete("excluir/{email}")]
        [Authorize]
        public async  Task<ActionResult> Excluir(ExcluirUsuarioCommand command, [FromServices]IExcuirUsuarioCommandHandle handle)
        {
            try
            {
                if (!await _repository.UsuarioExistente(command.Email))
                {
                    _logger.LogInformation($"Usuário com email: {command.Email} não está cadastrado");
                    return BadRequest($"Usuário com email: {command.Email} não está cadastrado");
                }

                handle.Excluir(command);

                return Ok();
            }
            catch (Exception error)
            {
                _logger.LogError($"{error.InnerException} :: {error.Message}");
                throw new Exception(error.Message);
            }
        }

        [HttpPatch("ativar")]
        [AllowAnonymous]
        public async Task<ActionResult> Ativar([FromBody]AtivarUsuarioCommand command, [FromServices]IAtivarUsuarioCommandHandle handle)
        {
            try
            {
                if (!await _repository.UsuarioExistente(command.Email))
                {
                    _logger.LogInformation($"Usuário não está cadastrado");
                    return BadRequest($"Usuário não está cadastrado");
                }

                if (command.CodigoDeAtivacao == 0)
                {
                    _logger.LogInformation($"O código de ativação não foi informado");
                    return BadRequest($"O código de ativação não foi informado");
                }

                await handle.Ativar(command);

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
