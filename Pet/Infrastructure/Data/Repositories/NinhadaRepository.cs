using Microsoft.AspNetCore.Mvc;
using Pet.App.Entities.PgSQL;
using Pet.App.Gateways;
using Pet.Infrastructure.Data.Config;
using Pet.App.Entities.Request;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Drawing2D;


namespace Pet.Infrastructure.Data.Repositories
{
    public class NinhadaRepository : INinhadaInterface
    {
        private readonly AppDbContext _context;

        public NinhadaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Ninhada> GetByIdAsync(int id)
        {
            var ninhadas = await _context.Ninhada
                                .Where(x => x.Ativo == true && x.Id == id)
                                .Include(x => x.Matriz) // Inclua a navegação para Matriz
                                .FirstOrDefaultAsync(); // Corrigido para ToListAsync()
            Console.WriteLine(ninhadas);
            return ninhadas;
        }

        public async Task<MatrizDTO> GetByMatrizIdAsync(int id)
        {
            var ninhadaWhithMatriz = await _context.Ninhada
                                .Where(x => x.Ativo == true && x.MatrizId == id)
                                .Include(x => x.Matriz) // Inclua a navegação para Matriz
                                .FirstOrDefaultAsync(); // Corrigido para ToListAsync()

            // Filtra ninhadas ativas da matriz
            var matrizWithNinhadas = await _context.Matriz
                                        .Where(m => m.Id == id && m.Ativo == true)
                                        .Include(m => m.Ninhadas) // Inclua as ninhadas associadas
                                        .FirstOrDefaultAsync();

            var dto = new MatrizDTO
            {
                Id = matrizWithNinhadas.Id,
                Nome = matrizWithNinhadas.Nome,
                Cor = matrizWithNinhadas.Cor,
                DataNascimento = matrizWithNinhadas.DataNascimento,
                Ativo = matrizWithNinhadas.Ativo,
                Ninhadas = matrizWithNinhadas.Ninhadas
                       .Where(n => n.Ativo) // Filtra ninhadas ativas
                       .Select(n => new NinhadaDTO
                       {
                           Id = n.Id,
                           Nome = n.Nome,
                           Quantidade = n.Quantidade,
                           DataNascimento = n.DataNascimento,
                           MatrizId = n.MatrizId,
                           Ativo = n.Ativo
                       })
                       .ToList()
            };

            return dto;
        }


        public async Task<ActionResult<Ninhada>> CreateNinhada(NinhadaDTO ninhadaDTO)
        {
            var ninhada = new Ninhada
            {
                Nome = ninhadaDTO.Nome,
                Quantidade = ninhadaDTO.Quantidade,
                DataNascimento = ninhadaDTO.DataNascimento,
                MatrizId = ninhadaDTO.MatrizId,
                Ativo = true
            };
            await _context.AddAsync(ninhada);
            await _context.SaveChangesAsync();
            return ninhada;
        }

        public async Task<ActionResult<Ninhada>> UpdateNinhada(NinhadaDTO ninhadaDTO, int id)
        {

            var ninhadaExists = await _context.Ninhada.FindAsync(id);
            if (ninhadaExists == null)
            {
                return null;
            }

            ninhadaExists.Nome = ninhadaDTO.Nome;
            ninhadaExists.Quantidade = ninhadaDTO.Quantidade;
            ninhadaExists.DataNascimento = ninhadaDTO.DataNascimento;
            await _context.SaveChangesAsync();
            return ninhadaExists;

        }

        public async Task<ActionResult<Ninhada>> DeleteNinhada(int id)
        {

            var matrizExists = await _context.Ninhada.FindAsync(id);
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



