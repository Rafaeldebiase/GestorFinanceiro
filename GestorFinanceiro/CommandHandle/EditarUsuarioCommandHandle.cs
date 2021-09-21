using Data.Interfaces;
using Domain.Entities;
using Domain.ObjectValues;
using GestorFinanceiro.Commands;
using GestorFinanceiro.ICommandHandle;

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

        public void EditarCommand(EditarUsuarioCommand command)
        {
            Usuario = _repository.BuscarUsuario(command.Email);

            VerificaNomeCompleto(command);
            VerificaEndereco(command);
            VerificaDataNascimento(command);





        }

        private void VerificaDataNascimento(EditarUsuarioCommand command)
        {
            if(Usuario.DataNascimento != command.DataNascimento)
            {
                Usuario.AlteraDataNascimento(command.DataNascimento);
            }
        }

        private void VerificaEndereco(EditarUsuarioCommand command)
        {
            var endereco = new
            {
                Logradouro = command.Logradouro,
                Numero = command.Numero,
                Complemento = command.Complemento,
                Bairro = command.Bairro,
                Cidade = command.Cidade,
                Estado = command.Estado,
                Pais = command.Pais,
                Cep = command.Cep
            };

            if(!Usuario.Endereco.Equals(endereco))
            {
                var end = new Endereco(
                        endereco.Logradouro,
                        endereco.Numero,
                        endereco.Complemento,
                        endereco.Bairro,
                        endereco.Cidade,
                        endereco.Estado,
                        endereco.Pais,
                        endereco.Cep
                    );

                Usuario.AlterarEndereco(end);
            }
        }

        private void VerificaNomeCompleto(EditarUsuarioCommand command)
        {
            var nomeCompleto = new
            {
                PrimeiroNome = command.PrimeiroNome,
                UltimoNome = command.UltimoNome
            };

            if (!Usuario.NomeCompleto.Equals(nomeCompleto))
            {
                var nome = new NomeCompleto(nomeCompleto.PrimeiroNome, nomeCompleto.UltimoNome);
                Usuario.AlterarNome(nome);
            }
        }
    }
}
