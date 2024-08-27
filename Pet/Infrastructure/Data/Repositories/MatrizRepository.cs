using Microsoft.AspNetCore.Mvc;
using Pet.App.Entities.PgSQL;
using Pet.App.Gateways;
using Pet.Infrastructure.Data.Config;
using Pet.App.Entities.Request;
using Microsoft.EntityFrameworkCore;


namespace Pet.Infrastructure.Data.Repositories
{
    public class MatrizRepository : IRepositoryInterface
    {
        private readonly AppDbContext _context;

        public MatrizRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Matriz> GetByIdAsync(int id)
        {
            var matriz = await _context.Matriz.Where(x => x.Ativo ==true && x.Id == id).SingleOrDefaultAsync();
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

        public async Task<ActionResult<Matriz>> UpdateMatriz(MatrizDTO matrizDto, int id)
        {

            var matrizExists = await _context.Matriz.FindAsync(id);
            if (matrizExists == null)
            {
                return null;
            }

            matrizExists.Nome = matrizDto.Nome;
            matrizExists.Cor = matrizDto.Cor;
            matrizExists.DataNascimento = matrizDto.DataNascimento;
                await _context.SaveChangesAsync();
                return matrizExists;

        }

        public async Task<ActionResult<Matriz>> DeleteMatriz(int id)
        {

            var matrizExists = await _context.Matriz.FindAsync(id);
            if (matrizExists == null)
            {
                return null;
            }

            matrizExists.Ativo = false;

            await _context.SaveChangesAsync();
            return matrizExists;

        }

    }
}



