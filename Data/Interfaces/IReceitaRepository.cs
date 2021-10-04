using Domain.Entities;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IReceitaRepository
    {
        Task<bool> CriarReceita(Receita receita, string usuarioId);
    }
}
