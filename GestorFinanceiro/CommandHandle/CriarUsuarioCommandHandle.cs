using Data.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Domain.ObjectValues;
using GestorFinanceiro.Commands;
using GestorFinanceiro.ICommandHandle;
using GestorFinanceiro.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace GestorFinanceiro.CommandHandle
{
    public class CriarUsuarioCommandHandle : ICriarUsuarioCommandHandle
    {
        private readonly IUsuarioRepository _repository;
        private readonly ILogger<CriarUsuarioCommandHandle> _logger;
        private readonly IEnvioDeEmailService _envioDeEmailService;

        public CriarUsuarioCommandHandle(IUsuarioRepository repository, ILogger<CriarUsuarioCommandHandle> logger,
            IEnvioDeEmailService envioDeEmailService)
        {
            _repository = repository;
            _logger = logger;
            _envioDeEmailService = envioDeEmailService;
        }

        public async Task<bool> Criar(CriarUsuarioCommand command)
        {
            try
            {
                var emailEnviado = false;
                var resultado = false;
                var codigo = new GeradorDeCodigo().Generator();

                emailEnviado = _envioDeEmailService.Enviar(command.Email, codigo, command.PrimeiroNome);

                if (emailEnviado)
                {
                    var usuario = CriarUsuario(command);
                    usuario.InserirCodigoDeAtivacao(codigo);
                    resultado = await _repository.CriarUsuarioAsync(usuario);
                    return resultado;

                }

                return resultado;
            }
            catch (Exception error)
            {
                _logger.LogError($"{error.InnerException} :: {error.Message}");
                throw;
            }
           
        }

        private Usuario CriarUsuario(CriarUsuarioCommand command)
        {
            var nomeCompleto = CriarNomeCompleto(command.PrimeiroNome, command.UltimoNome);
            var email = CriarEmail(command.Email);
            var senha = CriarSenha(command.Senha);
            var endereco = CriarEndereco(command);
            var genero = CriarGenero(command.Genero);
            var dataNascimento = CriarDataNascimento(command.DataNascimento);
            var usuario = new Usuario(
                    nomeCompleto,
                    email,
                    senha,
                    dataNascimento,
                    genero,
                    endereco
                );

            return usuario;
        }

        private Senha CriarSenha(string senha) =>
            new Senha(senha);

        private DateTime? CriarDataNascimento(DateTime? dataNascimento)
        {
            if (dataNascimento == null) return null;

            return dataNascimento;
        }

        private Genero CriarGenero(int? genero)
        {
            switch (genero)
            {
                case 0:
                    return Genero.MASCULINO;
                case 1:
                    return Genero.FEMININO;
                default:
                    return Genero.NAO_INFORMADO;
            }
        }

        private static NomeCompleto CriarNomeCompleto(string primeiroNome, string ultimoNome) =>
          new NomeCompleto(primeiroNome, ultimoNome);

        private static Email CriarEmail(string address) =>
            new Email(address);

        private static Endereco CriarEndereco(CriarUsuarioCommand command) =>
          new Endereco(
              command.Logradouro,
              command.Numero,
              command.Complemento,
              command.Bairro,
              command.Cidade,
              command.Estado,
              command.Pais,
              command.Cep
              );

    }
}
