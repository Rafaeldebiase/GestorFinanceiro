using GestorFinanceiro.Commands;
using System.Threading.Tasks;

namespace GestorFinanceiro.ICommandHandle
{
    public interface IExcluirCategoriaCommandHandle
    {
        Task<bool> Excluir(ExluirCategoriaCommand command, string usuarioId);
    }
}
