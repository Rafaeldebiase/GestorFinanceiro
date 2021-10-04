using GestorFinanceiro.Commands;
using System.Threading.Tasks;

namespace GestorFinanceiro.ICommandHandle
{
    public interface ICriarCategoriaCommandHandle
    {
        Task<bool> Criar(CriarCategoriaCommand command, string usuarioId);
    }
}
