using Microsoft.AspNetCore.Mvc;
using Pet.App.Entities.PgSQL;
using Pet.App.Gateways;
using Pet.Infrastructure.Data.Config;
using Pet.App.Entities.Request;
using Microsoft.EntityFrameworkCore;


namespace Pet.Infrastructure.Data.Repositories
{
    public class UsuarioRepository : IUsuarioInterface
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {
            var usuario = await _context.Usuario.Where(x => x.Ativo == true && x.Id == id).SingleOrDefaultAsync();
            return usuario;
        }

        public async Task<ActionResult<Usuario>> CreateUsuario(UsuarioDTO usuarioDTO, string salt)
        {
            var matriz = new Usuario
            {
                Username = usuarioDTO.Username ?? string.Empty,
                Password = usuarioDTO.Password ?? string.Empty,
                Salt = salt,
                Ativo = true
            };
            await _context.AddAsync(matriz);
            await _context.SaveChangesAsync();
            return matriz;
        }

        public async Task<ActionResult<Usuario>> UpdateUsuario(UsuarioDTO usuarioDTO, int id, string salt)
        {

            var usuarioExists = await _context.Usuario.FindAsync(id);
            if (usuarioExists == null)
            {
                return null;
            }

            usuarioExists.Username = usuarioDTO.Username;
            usuarioExists.Password = usuarioDTO.Password;
            usuarioExists.Salt = salt;
            await _context.SaveChangesAsync();
            return usuarioExists;

        }

        public async Task<ActionResult<Usuario>> DeleteUsuario(int id)
        {

            var usuarioExists = await _context.Usuario.FindAsync(id);
            if (usuarioExists == null)
            {
                return null;
            }

            usuarioExists.Ativo = false;

            await _context.SaveChangesAsync();
            return usuarioExists;

        }

    }
}



