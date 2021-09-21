using GestorFinanceiro.Commands;

namespace GestorFinanceiro.Interfaces
{
    public interface ICriarUsuarioCommandHandle
    {
        void CriarCommand(CriarUsuarioCommand command);
    }
}
