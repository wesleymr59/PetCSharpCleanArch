using Microsoft.AspNetCore.Mvc;
using Pet.App.Entities.PgSQL;
using Pet.App.Gateways;
using Pet.Infrastructure.Data.Config;
using System.Runtime.ConstrainedExecution;
using Pet.App.Entities.Request;

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

        public async Task<ActionResult<Matriz>> CreateMatriz(MatrizDTO matrizDto)
        {
            var matriz = new Matriz
            {
                Nome = matrizDto.Nome,
                Cor = matrizDto.Cor,
                DataNascimento = matrizDto.DataNascimento,
                Ativo = true
            };
            await _context.AddAsync(matriz);
            await _context.SaveChangesAsync();
            return matriz;
        }

    }
    }
    
    

