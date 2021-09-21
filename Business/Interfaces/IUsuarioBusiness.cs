using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IUsuarioBusiness
    {
        bool UsuarioExistente(string email);
        Task CriarUsuario(UsuarioDto usuarioDto);
    }
}