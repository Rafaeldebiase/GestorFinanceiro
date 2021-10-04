using Data.Dto;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<UsuarioDto> Autenticar(string email, string senha);
        Task<UsuarioDto> BuscarUsuarioPeloId(string id);
        Task<bool> CriarUsuarioAsync(Usuario usuario);
        Task<bool> Editar(Usuario usuario);
        Task<bool> Excluir(string email);
        Task<bool> UsuarioExistente(string email);
        Task<UsuarioDto> BuscarUsuarioPeloEmail(string email);
        Task<string> BuscarCodigoDeAtivacao(string email);
        Task Ativar(string email);
        Task<IEnumerable<UsuarioDto>> BuscarTodos();
    }
}
