using GestorFinanceiro.Commands;
using System.Threading.Tasks;

namespace GestorFinanceiro.ICommandHandle
{
    public interface IEditarCategoriaCommandHandle
    {
        Task<bool> Editar(EditarCategoriaCommand command, string usuarioId);
    }
}
