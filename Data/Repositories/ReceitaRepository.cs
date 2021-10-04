using Dapper;
using Data.Interfaces;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;
using System;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ReceitaRepository : IReceitaRepository
    {
        private readonly ILogger<ReceitaRepository> _logger;
        private readonly string _connectionString;

        public ReceitaRepository(ILogger<ReceitaRepository> logger, IConfiguration configuration)
        {
            _logger = logger;
            _connectionString = configuration.GetSection("Postgres").GetValue<string>("ConnectionString");
        }
        public async Task<bool> CriarReceita(Receita receita, string usuarioId)
        {
            try
            {
                var query = $@"insert into finance.receita (
                                id,
                                usuario_id,
                                categoria_id,
                                valor,
                                origem,
                                descricao,
                                data_cadastro,
                                data_receita
                                ) values (
                                '{receita.Id}',
                                '{usuarioId}',
                                '{receita.CategoriaId}',
                                {receita.Valor},
                                '{receita.Origem}',
                                '{receita.DataDeCadastro}',
                                '{receita.DataDaReceita}'
                            )";

                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    var resultado = await connection.ExecuteAsync(query);
                    return resultado > 0;
                }
            }
            catch (NpgsqlException error)
            {
                _logger.LogError($"{error.InnerException} :: {error.Message}");
                throw new Exception($"{error.InnerException} :: {error.Message}");
            }
        }
    }
}
