using Dapper;
using Data.Dto;
using Data.Interfaces;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Text;
using System.Collections.Generic;

namespace Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string _connectionString;

        private readonly ILogger<UsuarioRepository> _logger;

        public UsuarioRepository(IConfiguration configuration, ILogger<UsuarioRepository> logger)
        {
            _connectionString = configuration.GetSection("Postgres").GetValue<string>("ConnectionString");
            _logger = logger;
        }

        public async Task<UsuarioDto> Autenticar(string email, string senha)
        {
            try
            {
                var query = $@"select 
                                id as {nameof(UsuarioDto.Id)},
                                primeiro_nome as {nameof(UsuarioDto.PrimeiroNome)},
	                            ultimo_nome as {nameof(UsuarioDto.UltimoNome)},
	                            email as {nameof(UsuarioDto.Email)},
	                            data_nascimento as {nameof(UsuarioDto.DataNascimento)},
	                            Genero as {nameof(UsuarioDto.Genero)},
	                            logradouro as {nameof(UsuarioDto.Logradouro)},
                                numero as {nameof(UsuarioDto.Numero)}, 
                                complemento as {nameof(UsuarioDto.Complemento)},
                                bairro as {nameof(UsuarioDto.Bairro)},
                                cidade as {nameof(UsuarioDto.Cidade)}, 
                                estado as {nameof(UsuarioDto.Estado)}, 
                                pais as {nameof(UsuarioDto.Pais)},
                                cep as {nameof(UsuarioDto.Cep)},
	                            ativo as {nameof(UsuarioDto.Ativo)},
	                            funcao as {nameof(UsuarioDto.Funcao)}
                                from finance.usuario
                                where email = '{email}' and senha = '{senha}'";

                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    var usuarioDtos = await connection.QueryAsync<UsuarioDto>(query);
                    return usuarioDtos.FirstOrDefault();
                }
            }
            catch (NpgsqlException error)
            {
                _logger.LogError($"{error.InnerException} :: {error.Message}");
                throw new Exception($"{error.InnerException} :: {error.Message}");
            }
        }

        public async Task<UsuarioDto> BuscarUsuarioPeloEmail(string email)
        {
            try
            {
                var query = $@"select
                                id as {nameof(UsuarioDto.Id)},
                                primeiro_nome as {nameof(UsuarioDto.PrimeiroNome)},
	                            ultimo_nome as {nameof(UsuarioDto.UltimoNome)},
	                            email as {nameof(UsuarioDto.Email)},
	                            data_nascimento as {nameof(UsuarioDto.DataNascimento)},
	                            Genero as {nameof(UsuarioDto.Genero)},
	                            logradouro as {nameof(UsuarioDto.Logradouro)},
                                numero as {nameof(UsuarioDto.Numero)}, 
                                complemento as {nameof(UsuarioDto.Complemento)},
                                bairro as {nameof(UsuarioDto.Bairro)},
                                cidade as {nameof(UsuarioDto.Cidade)}, 
                                estado as {nameof(UsuarioDto.Estado)}, 
                                pais as {nameof(UsuarioDto.Pais)},
                                cep as {nameof(UsuarioDto.Cep)},
	                            ativo as {nameof(UsuarioDto.Ativo)},
	                            funcao as {nameof(UsuarioDto.Funcao)}
                                from finance.usuario
                                where id = '{email}'";

                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    var usuarioDtos = await connection.QueryAsync<UsuarioDto>(query);
                    return usuarioDtos.FirstOrDefault();
                }
            }
            catch (NpgsqlException error)
            {
                _logger.LogError($"{error.InnerException} :: {error.Message}");
                throw new Exception($"{error.InnerException} :: {error.Message}");
            }

        }

        public async Task<UsuarioDto> BuscarUsuarioPeloId(string id)
        {
            try
            {
                var query = $@"select
                                id as {nameof(UsuarioDto.Id)},
                                primeiro_nome as {nameof(UsuarioDto.PrimeiroNome)},
	                            ultimo_nome as {nameof(UsuarioDto.UltimoNome)},
	                            email as {nameof(UsuarioDto.Email)},
	                            data_nascimento as {nameof(UsuarioDto.DataNascimento)},
	                            Genero as {nameof(UsuarioDto.Genero)},
	                            logradouro as {nameof(UsuarioDto.Logradouro)},
                                numero as {nameof(UsuarioDto.Numero)}, 
                                complemento as {nameof(UsuarioDto.Complemento)},
                                bairro as {nameof(UsuarioDto.Bairro)},
                                cidade as {nameof(UsuarioDto.Cidade)}, 
                                estado as {nameof(UsuarioDto.Estado)}, 
                                pais as {nameof(UsuarioDto.Pais)},
                                cep as {nameof(UsuarioDto.Cep)},
	                            ativo as {nameof(UsuarioDto.Ativo)},
	                            funcao as {nameof(UsuarioDto.Funcao)}
                                from finance.usuario
                                where id = '{id}'";

                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    var usuarioDtos = await connection.QueryAsync<UsuarioDto>(query);
                    return usuarioDtos.FirstOrDefault();
                }
            }
            catch (NpgsqlException error)
            {
                _logger.LogError($"{error.InnerException} :: {error.Message}");
                throw new Exception($"{error.InnerException} :: {error.Message}");
            }

        }

        public async Task<bool> CriarUsuarioAsync(Usuario usuario)
        {
            try
            {
                var query = new StringBuilder();
                query.AppendLine("insert into finance.usuario (");
                query.AppendLine("id,");
                query.AppendLine("primeiro_nome,");
                query.AppendLine("ultimo_nome,");
                query.AppendLine("email,");
                query.AppendLine("senha,");

                if (usuario.DataNascimento == null)
                {
                    query.AppendLine(null);
                }
                else
                {
                    query.AppendLine("data_nascimento,");
                }

                query.AppendLine("genero,");
                query.AppendLine("logradouro,");

                if (usuario.Endereco.Numero == null)
                {
                    query.AppendLine(null);
                }
                else
                {
                    query.AppendLine("numero,");
                }

                query.AppendLine("complemento,");
                query.AppendLine("bairro,");
                query.AppendLine("cidade,");
                query.AppendLine("estado,");
                query.AppendLine("pais,");
                query.AppendLine("cep,");
                query.AppendLine("ativo,");
                query.AppendLine("codigo_ativacao,");
                query.AppendLine("funcao");
                query.AppendLine(") values (");
                query.AppendLine($"'{usuario.Id}',");
                query.AppendLine($"'{usuario.NomeCompleto.PrimeiroNome}',");
                query.AppendLine($"'{usuario.NomeCompleto.UltimoNome}',");
                query.AppendLine($"'{usuario.Email.Address}',");
                query.AppendLine($"'{usuario.Senha.Codigo}',");

                if (usuario.DataNascimento == null)
                {
                    query.AppendLine(null);
                }
                else
                {
                    query.AppendLine($"{usuario.DataNascimento}");
                }

                query.AppendLine($"'{usuario.Genero}',");
                query.AppendLine($"'{usuario.Endereco.Logradouro}',");

                if (usuario.Endereco.Numero == null)
                {
                    query.AppendLine(null);
                }
                else
                {
                    query.AppendLine($"{usuario.Endereco.Numero},");
                }

                query.AppendLine($"'{usuario.Endereco.Complemento}',");
                query.AppendLine($"'{usuario.Endereco.Bairro}',");
                query.AppendLine($"'{usuario.Endereco.Cidade}',");
                query.AppendLine($"'{usuario.Endereco.Estado}',");
                query.AppendLine($"'{usuario.Endereco.Pais}',");
                query.AppendLine($"'{usuario.Endereco.Cep}',");
                query.AppendLine($"{usuario.Ativo},");
                query.AppendLine($"{usuario.CodigoDeAtivacao},");
                query.AppendLine($"'{usuario.Funcao}')");

                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    var row = await connection.ExecuteAsync(query.ToString());
                    return row == 1;
                }
            }
            catch (NpgsqlException error)
            {
                _logger.LogError($"{error.InnerException} :: {error.Message}");
                throw new Exception($"{error.InnerException} :: {error.Message}");
            }

        }

        public async Task<bool> Editar(Usuario usuario)
        {
            try
            {
                var query = new StringBuilder();
                query.AppendLine("update finance.usuario");
                query.AppendLine("set");
                query.AppendLine($"primeiro_nome = '{usuario.NomeCompleto.PrimeiroNome}', ");
                query.AppendLine($"ultimo_nome = '{usuario.NomeCompleto.UltimoNome}', ");
                query.AppendLine($"email = '{usuario.Email.Address}', ");

                if (usuario.DataNascimento == null)
                {
                    query.AppendLine(null);
                }
                else
                {
                    query.AppendLine($"data_nascimento = '{usuario.DataNascimento}'");
                }

                query.AppendLine($"genero = '{usuario.Genero}',");
                query.AppendLine($"logradouro = '{usuario.Endereco.Logradouro}', ");

                if (usuario.Endereco.Numero == null)
                {
                    query.AppendLine(null);
                }
                else
                {
                    query.AppendLine($"numero = {usuario.Endereco.Numero},");
                }

                query.AppendLine($"complemento = '{usuario.Endereco.Complemento}',");
                query.AppendLine($"bairro = '{usuario.Endereco.Bairro}',");
                query.AppendLine($"cidade = '{usuario.Endereco.Cidade}',");
                query.AppendLine($"estado = '{usuario.Endereco.Estado}',");
                query.AppendLine($"pais = '{usuario.Endereco.Pais}',");
                query.AppendLine($"cep = '{usuario.Endereco.Cep}' ");
                query.AppendLine($"where id = '{usuario.Id}'");

                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    var row = await connection.ExecuteAsync(query.ToString());
                    return row == 1;
                }
            }
            catch (NpgsqlException error)
            {
                _logger.LogError($"{error.InnerException} :: {error.Message}");
                throw new Exception($"{error.InnerException} :: {error.Message}");
            }
        }

        public async Task<bool> Excluir(string email)
        {
            try
            {
                var query = $@"delete from finance.usuario
                          where email = '{email}'";

                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    var emailAddress = await connection.QueryAsync<string>(query);
                    return emailAddress.Count() > 0;
                }
            }
            catch (NpgsqlException error)
            {
                _logger.LogError($"{error.InnerException} :: {error.Message}");
                throw new Exception($"{error.InnerException} :: {error.Message}");
            }
        }

        public async Task<bool> UsuarioExistente(string email)
        {
            try
            {
                var query = $@"select email from finance.usuario
                                where email = '{email}'";

                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    var emailAddress = await connection.QueryAsync<string>(query);
                    return emailAddress.Count() > 0;
                }
            }
            catch (NpgsqlException error)
            {
                _logger.LogError($"{error.InnerException} :: {error.Message}");
                throw new Exception($"{error.InnerException} :: {error.Message}");
            }

        }

        public async Task<string> BuscarCodigoDeAtivacao(string email)
        {
            try
            {
                var query = $@"select codigo_ativacao from finance.usuario
                          where email = '{email}'";

                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    var codigoAtivacao = await connection.QueryAsync<string>(query);
                    return codigoAtivacao.FirstOrDefault();
                }
            }
            catch (NpgsqlException error)
            {
                _logger.LogError($"{error.InnerException} :: {error.Message}");
                throw new Exception($"{error.InnerException} :: {error.Message}");
            }
        }

        public async Task Ativar(string email)
        {
            try
            {
                var query = $@"update finance.usuario
                                set ativo = {true}
                                where email = '{email}'";

                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    await connection.ExecuteAsync(query);
                }
            }
            catch (NpgsqlException error)
            {
                _logger.LogError($"{error.InnerException} :: {error.Message}");
                throw new Exception($"{error.InnerException} :: {error.Message}");
            }
        }

        public async Task<IEnumerable<UsuarioDto>> BuscarTodos()
        {
            try
            {
                var query = $@"select * from finance.usuario";

                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    return await connection.QueryAsync<UsuarioDto>(query);
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
