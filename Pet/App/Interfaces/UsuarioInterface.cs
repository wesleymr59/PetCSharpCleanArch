using Microsoft.AspNetCore.Mvc;
using Pet.App.Entities.PgSQL;
using Pet.App.Entities.Request;

namespace Pet.App.Gateways
{
    public interface IUsuarioInterface
    {

        Task<Usuario> GetByIdAsync(int id);
        Task<ActionResult<Usuario>> CreateUsuario(UsuarioDTO usuario, string salt);
        Task<ActionResult<Usuario>> UpdateUsuario(UsuarioDTO usuario, int id, string salt);
        Task<ActionResult<Usuario>> DeleteUsuario(int id);
    }
}
