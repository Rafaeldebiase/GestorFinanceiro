using GestorFinanceiro.Commands;
using System.Threading.Tasks;

namespace GestorFinanceiro.ICommandHandle
{
    public interface ICriarUsuarioCommandHandle
    {
        Task<bool> Criar(CriarUsuarioCommand command);
    }
}
