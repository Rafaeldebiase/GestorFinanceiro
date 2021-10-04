using GestorFinanceiro.Commands;
using System.Threading.Tasks;

namespace GestorFinanceiro.ICommandHandle
{
    public interface IEditarReceitaCommandHandle
    {
        Task<bool> Editar(EditarReceitaCommand command, string usuarioId);
    }
}
