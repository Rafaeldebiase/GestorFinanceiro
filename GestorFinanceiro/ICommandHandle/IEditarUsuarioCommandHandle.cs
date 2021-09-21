using GestorFinanceiro.Commands;

namespace GestorFinanceiro.ICommandHandle
{
    public interface IEditarUsuarioCommandHandle
    {
        void EditarCommand(EditarUsuarioCommand command);
    }
}
