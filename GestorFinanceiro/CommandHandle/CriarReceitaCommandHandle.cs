using Data.Interfaces;
using Domain.Entities;
using GestorFinanceiro.Commands;
using GestorFinanceiro.Controllers;
using GestorFinanceiro.ICommandHandle;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace GestorFinanceiro.CommandHandle
{
    public class CriarReceitaCommandHandle : ICriarReceitaCommandHandle
    {
        private readonly ILogger<ReceitaController> _logger;
        private readonly IReceitaRepository _repository;
        private readonly ICategoriaRepository _categoriaRepository;

        public CriarReceitaCommandHandle(ILogger<ReceitaController> logger, IReceitaRepository repository, ICategoriaRepository categoriaRepository)
        {
            _logger = logger;
            _repository = repository;
            _categoriaRepository = categoriaRepository;
        }

        public async Task<bool> Criar(CriarReceitaCommand command, string usuarioId)
        {
            try
            {
                var receita = new Receita(command.Valor, command.CategoriaId, command.DataDeRecebimento, command.Origem, command.Descricao);
                var resultado = await _repository.CriarReceita(receita, usuarioId);

                if(resultado)
                {
                    var categoriaDto = await _categoriaRepository.Buscar(usuarioId, command.CategoriaId);
                    var categoria = new Categoria(categoriaDto.Id, categoriaDto.Nome, categoriaDto.Descricao, categoriaDto.Somatorio);

                    categoria.Calcular(receita.Valor);

                    await _categoriaRepository.AlterarSomatorio(categoria, usuarioId);
                }

                return resultado;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
