using Data.Dto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<bool> Criar(Categoria categoria, string usuarioId);
        Task<IEnumerable<CategoriaDto>> BuscarTodos(string usuarioId);
        Task<CategoriaDto> Buscar(string usuarioId, Guid id);
        Task<bool> Editar(Categoria categoria, string usuarioId);
        Task<bool> Excluir(Guid id, string usuarioId);
        Task<bool> AlterarSomatorio(Categoria categoria, string usuarioId);
    }
}
