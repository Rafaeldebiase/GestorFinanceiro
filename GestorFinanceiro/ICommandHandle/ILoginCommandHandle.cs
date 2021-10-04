using GestorFinanceiro.Commands;
using GestorFinanceiro.Dto;
using System.Threading.Tasks;

namespace GestorFinanceiro.ICommandHandle
{
    public interface ILoginCommandHandle
    {
        Task<LoginDto> Authenticate(LoginCommand command);
        void Logout();
 
    }
}
