using Microsoft.AspNetCore.Mvc;
using Pet.App.Entities.PgSQL;
using Pet.App.Gateways;
using Pet.App.Entities.Request;
using Pet.App.Utils;

namespace Pet.App.UseCases
{
    public class UsuarioUseCase
    {
        private readonly IUsuarioInterface _usuarioInterface;
        private readonly HashPassword _hashPassword;
        public UsuarioUseCase(IUsuarioInterface usuarioInterface)
        {
            _usuarioInterface = usuarioInterface;
            _hashPassword = new HashPassword(); 
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {

            return await _usuarioInterface.GetByIdAsync(id);
        }

        public async Task<ActionResult<Usuario>> CreateUsuario(UsuarioDTO usuarioDTO)
        {
            var hashedPasswd = _hashPassword.HashPasswd(usuarioDTO.Password!); //! nega o valor nulo, sabendo que sempre sera um campo preenchido
            usuarioDTO.Password = hashedPasswd.Hash;
            return await _usuarioInterface.CreateUsuario(usuarioDTO, hashedPasswd.Salt);
        }
        public async Task<ActionResult<Usuario>> UpdateUsuario(UsuarioDTO usuarioDTO, int id)
        {
            var hashedPasswd = _hashPassword.HashPasswd(usuarioDTO.Password!); //! nega o valor nulo, sabendo que sempre sera um campo preenchido
            usuarioDTO.Password = hashedPasswd.Hash;
            return await _usuarioInterface.UpdateUsuario(usuarioDTO, id, hashedPasswd.Salt);
        }

        public async Task<ActionResult<Usuario>> DeleteUsuario(int id)
        {

            return await _usuarioInterface.DeleteUsuario(id);
        }

    }
}
