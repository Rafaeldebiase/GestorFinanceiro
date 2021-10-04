using GestorFinanceiro.Commands;
using System;
using System.Threading.Tasks;

namespace GestorFinanceiro.ICommandHandle
{
    public interface ICriarReceitaCommandHandle
    {
        Task<bool> Criar(CriarReceitaCommand command, string usuarioId);
        
    }
}
