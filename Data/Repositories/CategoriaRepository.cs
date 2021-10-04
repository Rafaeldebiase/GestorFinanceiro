using Dapper;
using Data.Dto;
using Data.Interfaces;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly ILogger<CategoriaRepository> _logger;
        private readonly string _connectionString;

        public CategoriaRepository(ILogger<CategoriaRepository> logger, IConfiguration configuration)
        {
            _logger = logger;
            _connectionString = configuration.GetSection("Postgres").GetValue<string>("ConnectionString");
        }

        public async Task<bool> AlterarSomatorio(Categoria categoria, string usuarioId)
        {
            try
            {
                var query = $@"update finance.categoria
                                set somatorio = '{categoria.Somatorio}'
                                where id = '{categoria.Id}' and usuario_id = '{usuarioId}'";

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

        public async Task<CategoriaDto> Buscar(string usuarioId, Guid id)
        {
            try
            {
                var query = $@"select id as {nameof(CategoriaDto.Id)}, 
                                nome as {nameof(CategoriaDto.Nome)}, 
                                descricao as {nameof(CategoriaDto.Descricao)},
                                somatorio as {nameof(CategoriaDto.Somatorio)}
                                from finance.categoria
                                where usuario_id = '{usuarioId}' and id = '{id}'";

                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    var resultado = await connection.QueryAsync<CategoriaDto>(query);
                    return resultado.FirstOrDefault();
                }
            }
            catch (NpgsqlException error)
            {
                _logger.LogError($"{error.InnerException} :: {error.Message}");
                throw new Exception($"{error.InnerException} :: {error.Message}");
            }
        }

        public async Task<IEnumerable<CategoriaDto>> BuscarTodos(string usuarioId)
        {
            try
            {
                var query = $@"select 
                                id as {nameof(CategoriaDto.Id)}, 
                                nome as {nameof(CategoriaDto.Nome)}, 
                                descricao as {nameof(CategoriaDto.Descricao)},
                                somatorio as {nameof(CategoriaDto.Somatorio)}
                                from finance.categoria
                                where usuario_id = '{usuarioId}'";

                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    var resultado = await connection.QueryAsync<CategoriaDto>(query);
                    return resultado;
                }
            }
            catch (NpgsqlException error)
            {
                _logger.LogError($"{error.InnerException} :: {error.Message}");
                throw new Exception($"{error.InnerException} :: {error.Message}");
            }
        }

        public async Task<bool> Criar(Categoria categoria, string usuarioId)
        {
            try
            {
                var query = $@"insert into finance.categoria (
                                id,
                                usuario_id,
                                nome,
                                descricao,
                                somatorio
                                ) values (
                                '{categoria.Id}',
                                '{usuarioId}',
                                '{categoria.Nome}',
                                '{categoria.Descricao}',
                                '{categoria.Somatorio}'
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

        public async Task<bool> Editar(Categoria categoria, string usuarioId)
        {
            try
            {
                var query = $@"update finance.categoria
                                set nome = '{categoria.Nome}',
                                    descricao = '{categoria.Descricao}'
                                where id = '{categoria.Id}' and usuario_id = '{usuarioId}'";

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

        public async Task<bool> Excluir(Guid id, string usuarioId)
        {
            try
            {
                var query = $@"delete from finance.categoria
                                where id = '{id}' and usuario_id = '{usuarioId}'";

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
