using Microsoft.AspNetCore.Mvc;
using Pet.App.Entities.PgSQL;
using Pet.App.Gateways;
using Pet.App.Entities.Request;

namespace Pet.App.UseCases
{
    public class MatrizUseCase
    {
        private readonly IRepositoryInterface _repositoryInterface;
        public MatrizUseCase(IRepositoryInterface repositoryInterface)
        {
            _repositoryInterface = repositoryInterface;
        }

        public async Task<Matriz?> GetByIdAsync(int id)
        {
            Console.WriteLine("hdjsauhdiuashduiawshuiodhasuidhaskjhdlj");
            return await _repositoryInterface.GetByIdAsync(id);
        }

        public async Task<ActionResult<Matriz>> CreateMatriz(MatrizDTO matriz)
        {
            Console.WriteLine("hdjsauhdiuashduiawshuiodhasuidhaskjhdlj");
            return await _repositoryInterface.CreateMatriz(matriz);
        }

    }
}
