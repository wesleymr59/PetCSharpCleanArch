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

            return await _repositoryInterface.GetByIdAsync(id);
        }

        public async Task<ActionResult<Matriz>> CreateMatriz(MatrizDTO matriz)
        {

            return await _repositoryInterface.CreateMatriz(matriz);
        }
        public async Task<ActionResult<Matriz>> UpdateMatriz(MatrizDTO matriz, int id)
        {

            return await _repositoryInterface.UpdateMatriz(matriz, id);
        }

        public async Task<ActionResult<Matriz>> DeleteMatriz(int id)
        {

            return await _repositoryInterface.DeleteMatriz(id);
        }

    }
}
