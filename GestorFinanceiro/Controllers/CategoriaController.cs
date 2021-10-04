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
    public class CategoriaController : ControllerBase
    {
        private readonly ILogger<CategoriaController> _logger;
        private readonly ICategoriaRepository _repository;

        public CategoriaController(ILogger<CategoriaController> logger, ICategoriaRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("buscartodos")]
        [Authorize]
        public async Task<IEnumerable<CategoriaDto>> BuscarTodos()
        {
            try
            {
                var usuarioId = User.Identity.Name;

                return await _repository.BuscarTodos(usuarioId);
            }
            catch (Exception error)
            {
                _logger.LogError($"{error.InnerException} :: {error.Message}");
                throw;
            }
        }

        [HttpGet("buscar/{id}")]
        [Authorize]
        public async Task<CategoriaDto> Buscar(Guid id)
        {
            try
            {
                var usuarioId = User.Identity.Name;

                return await _repository.Buscar(usuarioId, id);
            }
            catch (Exception error)
            {
                _logger.LogError($"{error.InnerException} :: {error.Message}");
                throw;
            }
        }

        [HttpPost("criar")]
        [Authorize]
        public async Task<ActionResult> Criar([FromBody]CriarCategoriaCommand command, [FromServices]ICriarCategoriaCommandHandle handle)
        {
            try
            {
                if(!command.EhValido())
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
        public async Task<ActionResult> Editar([FromBody]EditarCategoriaCommand command, [FromServices]IEditarCategoriaCommandHandle handle)
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

                return StatusCode(200);

            }
            catch (Exception error)
            {
                _logger.LogError($"{error.InnerException} :: {error.Message}");
                throw;
            }
        }

        [HttpDelete("excluir")]
        [Authorize]
        public async Task<ActionResult> Excluir([FromBody]ExluirCategoriaCommand command, [FromServices] IExcluirCategoriaCommandHandle handle)
        {
            try
            {
                if (command.Id == Guid.Empty)
                {
                    _logger.LogInformation($"Id não foi informado");
                    return BadRequest($"Id não foi informado");
                }

                var usuarioId = User.Identity.Name;

                var resultado = await handle.Excluir(command, usuarioId);

                return StatusCode(200);

            }
            catch (Exception error)
            {
                _logger.LogError($"{error.InnerException} :: {error.Message}");
                throw;
            }
        }
    }
}
