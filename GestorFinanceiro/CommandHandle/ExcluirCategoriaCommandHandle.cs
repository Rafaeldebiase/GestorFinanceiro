using Data.Interfaces;
using GestorFinanceiro.Commands;
using GestorFinanceiro.ICommandHandle;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace GestorFinanceiro.CommandHandle
{
    public class ExcluirCategoriaCommandHandle : IExcluirCategoriaCommandHandle
    {
        private readonly ILogger<EditarCategoriaHandle> _logger;
        private readonly ICategoriaRepository _repository;

        public ExcluirCategoriaCommandHandle(ILogger<EditarCategoriaHandle> logger, ICategoriaRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        public Task<bool> Excluir(ExluirCategoriaCommand command, string usuarioId)
        {
            try
            {
                return _repository.Excluir(command.Id, usuarioId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
