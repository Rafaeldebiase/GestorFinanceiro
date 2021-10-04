
using Data.Interfaces;
using Domain.Entities;
using GestorFinanceiro.Commands;
using GestorFinanceiro.ICommandHandle;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace GestorFinanceiro.CommandHandle
{
    public class CriarCategoriaCommandHandle : ICriarCategoriaCommandHandle
    {
        private readonly ICategoriaRepository _repository;
        private readonly ILogger<CriarCategoriaCommandHandle> _logger;

        public CriarCategoriaCommandHandle(ICategoriaRepository repository, ILogger<CriarCategoriaCommandHandle> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public Task<bool> Criar(CriarCategoriaCommand command, string usuarioId)
        {
            try
            {
                var categoria = new Categoria(command.Nome, command.Categoria);
                return _repository.Criar(categoria, usuarioId);
            }
            catch (Exception error)
            {
                _logger.LogError($"{error.InnerException} :: {error.Message}");
                throw;
            }
        }
    }
}
