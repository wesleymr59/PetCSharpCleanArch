using Microsoft.AspNetCore.Mvc;
using Pet.App.Entities.PgSQL;
using Pet.App.Gateways;
using Pet.Infrastructure.Data.Config;

namespace Pet.Infrastructure.Data.Repositories
{
    public class Repository : IRepositoryInterface
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Matriz> GetByIdAsync(int id)
        {
            var matriz = await _context.Matriz.FindAsync(id);
            if (matriz == null)
            {
                throw new KeyNotFoundException($"Entidade com o ID {id} não foi encontrada.");

            }
            return matriz;
        }
            
        }
    }
    
    

