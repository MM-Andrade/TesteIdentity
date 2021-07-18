using System.Threading.Tasks;
using TesteIdentity.API.DTOs;

namespace TesteIdentity.API.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioDTO> Criar(UsuarioDTO dto);
        Task<UsuarioDTO> Atualizar(UsuarioDTO dto, int id);
    }
}
