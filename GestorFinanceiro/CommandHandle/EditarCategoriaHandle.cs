using Data.Interfaces;
using Domain.Entities;
using GestorFinanceiro.Commands;
using GestorFinanceiro.ICommandHandle;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace GestorFinanceiro.CommandHandle
{
    public class EditarCategoriaHandle : IEditarCategoriaCommandHandle
    {
        private readonly ILogger<EditarCategoriaHandle> _logger;
        private readonly ICategoriaRepository _repository;

        public EditarCategoriaHandle(ILogger<EditarCategoriaHandle> logger, ICategoriaRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public Task<bool> Editar(EditarCategoriaCommand command, string usuarioId)
        {
            try
            {
                var categoria = new Categoria(command.Id, command.Nome, command.Descricao);

                return _repository.Editar(categoria, usuarioId);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
