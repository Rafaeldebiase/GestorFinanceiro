using GestorFinanceiro.Commands;

namespace GestorFinanceiro.ICommandHandle
{
    public interface IExcuirUsuarioCommandHandle
    {
        void Excluir(ExcluirUsuarioCommand command);
    }
}
