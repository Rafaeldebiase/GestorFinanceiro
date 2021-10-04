using GestorFinanceiro.Commands;
using System.Threading.Tasks;

namespace GestorFinanceiro.ICommandHandle
{
    public interface IAtivarUsuarioCommandHandle
    {
        Task Ativar(AtivarUsuarioCommand command);
    }
}
