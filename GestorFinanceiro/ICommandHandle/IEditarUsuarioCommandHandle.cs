using GestorFinanceiro.Commands;
using System;
using System.Threading.Tasks;

namespace GestorFinanceiro.ICommandHandle
{
    public interface IEditarUsuarioCommandHandle
    {
        Task<bool> EditarCommand(EditarUsuarioCommand command, string id );
    }
}
