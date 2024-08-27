using Microsoft.AspNetCore.Mvc;
using Pet.App.Entities.PgSQL;
using Pet.App.Gateways;
using Pet.App.Entities.Request;
using Pet.App.Entities.PgSQL;

namespace Pet.App.UseCases
{
    public class NinhadaUseCase
    {
        private readonly INinhadaInterface _ninhadaInterface;
        public NinhadaUseCase(INinhadaInterface ninhadaInterface)
        {
            _ninhadaInterface = ninhadaInterface;
        }

        public async Task<Ninhada> GetByIdAsync(int id)
        {

            return await _ninhadaInterface.GetByIdAsync(id);
        }

        public async Task<MatrizDTO> GetByMatrizIdAsync(int id)
        {

            return await _ninhadaInterface.GetByMatrizIdAsync(id);
        }

        public async Task<ActionResult<Ninhada>> CreateNinhada(NinhadaDTO ninhada)
        {

            return await _ninhadaInterface.CreateNinhada(ninhada);
        }
        public async Task<ActionResult<Ninhada>> UpdateNinhada(NinhadaDTO ninhada, int id)
        {

            return await _ninhadaInterface.UpdateNinhada(ninhada, id);
        }

        public async Task<ActionResult<Ninhada>> DeleteNinhada(int id)
        {

            return await _ninhadaInterface.DeleteNinhada(id);


        }
    }
}
