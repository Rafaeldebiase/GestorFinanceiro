using Data.Interfaces;
using GestorFinanceiro.Commands;
using GestorFinanceiro.ICommandHandle;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace GestorFinanceiro.Controllers
{
    [Route("api/v1/[controller]")]
    public class ReceitaController : ControllerBase
    {
        private readonly ILogger<ReceitaController> _logger;
        private readonly IReceitaRepository _repository;

        public ReceitaController(ILogger<ReceitaController> logger, IReceitaRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpPost("criar")]
        [Authorize]
        public async Task<ActionResult> Criar([FromBody] CriarReceitaCommand command, [FromServices] ICriarReceitaCommandHandle handle)
        {
            try
            {
                if (!command.EhValido())
                {
                    _logger.LogInformation($"{command.RetornaErros()}");
                    return BadRequest(command.RetornaErros());
                }

                var usuarioId = User.Identity.Name;

                var resultado = await handle.Criar(command, usuarioId);

                return StatusCode(201);

            }
            catch (Exception error)
            {
                _logger.LogError($"{error.InnerException} :: {error.Message}");
                throw;
            }
        }

        [HttpPatch("editar")]
        [Authorize]
        public async Task<ActionResult> Editar([FromBody]EditarReceitaCommand command, [FromServices] IEditarReceitaCommandHandle handle)
        {
            try
            {
                if (!command.EhValido())
                {
                    _logger.LogInformation($"{command.RetornaErros()}");
                    return BadRequest(command.RetornaErros());
                }

                var usuarioId = User.Identity.Name;

                var resultado = await handle.Editar(command, usuarioId);

                return StatusCode(201);

            }
            catch (Exception error)
            {
                _logger.LogError($"{error.InnerException} :: {error.Message}");
                throw;
            }
        }
    }
}
