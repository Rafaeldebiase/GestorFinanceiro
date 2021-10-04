using Data.Interfaces;
using GestorFinanceiro.Commands;
using GestorFinanceiro.ICommandHandle;

namespace GestorFinanceiro.CommandHandle
{
    public class ExcluirUsuárioCommandHandle : IExcuirUsuarioCommandHandle
    {
        private readonly IUsuarioRepository _repository;

        public ExcluirUsuárioCommandHandle(IUsuarioRepository repository)
        {
            _repository = repository;
        }
        public void Excluir(ExcluirUsuarioCommand command)
        {
            _repository.Excluir(command.Email);
        }
    }
}
