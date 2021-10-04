using Data.Dto;
using Data.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Domain.ObjectValues;
using GestorFinanceiro.Commands;
using GestorFinanceiro.ICommandHandle;
using System;
using System.Threading.Tasks;

namespace GestorFinanceiro.CommandHandle
{
    public class EditarUsuarioCommandHandle : IEditarUsuarioCommandHandle
    {
        private readonly IUsuarioRepository _repository;

        public EditarUsuarioCommandHandle(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public Usuario Usuario { get; private set; }

        public async Task<bool> EditarCommand(EditarUsuarioCommand command, string id)
        {
            Usuario = CriarUsuario(command, id);

            return await _repository.Editar(Usuario);
        }

        private Usuario CriarUsuario(EditarUsuarioCommand command, string id)
        {
            var nomeCompleto = CriarNomeCompleto(command.PrimeiroNome, command.UltimoNome);
            var email = CriarEmail(command.Email);
            var endereco = CriarEndereco(command);
            var genero = CriarGenero(command.Genero);
            var dataNascimento = CriarDataNascimento(command.DataNascimento);

            var usuario = new Usuario(
                    Guid.Parse(id),
                    nomeCompleto,
                    email,
                    dataNascimento,
                    genero,
                    endereco
                ); 

            return usuario;

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

        private DateTime? CriarDataNascimento(DateTime? dataNascimento)
        {
            if (dataNascimento == null) return null;

            return dataNascimento;
        }

        private static NomeCompleto CriarNomeCompleto(string primeiroNome, string ultimoNome) =>
            new NomeCompleto(primeiroNome, ultimoNome);

        private static Email CriarEmail(string address) =>
            new Email(address);

        private static Endereco CriarEndereco(EditarUsuarioCommand command) =>
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
