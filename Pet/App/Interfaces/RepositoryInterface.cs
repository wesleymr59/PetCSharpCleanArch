using Microsoft.AspNetCore.Mvc;
using Pet.App.Entities.PgSQL;
using Pet.App.Entities.Request;

namespace Pet.App.Gateways
{
    public interface IRepositoryInterface
    {

        Task<Matriz> GetByIdAsync(int id);
        Task<ActionResult<Matriz>> CreateMatriz(MatrizDTO matriz);
        Task<ActionResult<Matriz>> UpdateMatriz(MatrizDTO matriz, int id);
        Task<ActionResult<Matriz>> DeleteMatriz(int id);
    }
}
