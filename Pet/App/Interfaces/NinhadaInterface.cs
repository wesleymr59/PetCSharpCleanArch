using Microsoft.AspNetCore.Mvc;
using Pet.App.Entities.PgSQL;
using Pet.App.Entities.Request;
using static Pet.App.Entities.PgSQL.Matriz;

namespace Pet.App.Gateways
{
    public interface INinhadaInterface
    {

        Task<Ninhada> GetByIdAsync(int id);
        Task<MatrizDTO> GetByMatrizIdAsync(int id);
        Task<ActionResult<Ninhada>> CreateNinhada(NinhadaDTO ninhada);
        Task<ActionResult<Ninhada>> UpdateNinhada(NinhadaDTO ninhada, int id);
        Task<ActionResult<Ninhada>> DeleteNinhada(int id);
    }
}
