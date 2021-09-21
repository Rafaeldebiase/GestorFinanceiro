using Data.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Domain.ObjectValues;
using GestorFinanceiro.Commands;
using GestorFinanceiro.Interfaces;
using Microsoft.Extensions.Logging;

namespace GestorFinanceiro.CommandHandle
{
    public class CriarUsuarioCommandHandle : ICriarUsuarioCommandHandle
    {
        private readonly IUsuarioRepository _repository;
        private readonly ILogger<CriarUsuarioCommandHandle> _logger;

        public CriarUsuarioCommandHandle(IUsuarioRepository repository, ILogger<CriarUsuarioCommandHandle> logger)
        {
            _repository = repository;
            this._logger = logger;
        }
        public void CriarCommand(CriarUsuarioCommand command)
        {
            var nomeCompleto = CriarNomeCompleto(command);
            var email = CriarEmail(command);
            var senha = CriarSenha(command);
            var endereco = CriarEndereco(command);
            var usuario = new Usuario(
                    nomeCompleto,
                    email,
                    senha,
                    command.DataNascimento,
                    (Genero)command.Genero,
                    endereco
                );

            _repository.CriarUsuario(usuario);

        }

        private NomeCompleto CriarNomeCompleto(CriarUsuarioCommand command) =>
            new NomeCompleto(command.PrimeiroNome, command.UltimoNome);

        private Email CriarEmail(CriarUsuarioCommand command) =>
            new Email(command.Email);

        private Senha CriarSenha(CriarUsuarioCommand command) =>
            new Senha(command.Senha);

        private Endereco CriarEndereco(CriarUsuarioCommand command) =>
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
