using Microsoft.AspNetCore.Mvc;
using Pet.App.Entities.PgSQL;
using Pet.App.Gateways;
using Pet.App.UseCases;
using Pet.Infrastructure.Data.Config;
using System;
using Pet.App.Entities.Request;

namespace Pet.App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NinhadaController : ControllerBase
    {
        private readonly NinhadaUseCase _ninhadaUseCase;

        public NinhadaController( NinhadaUseCase ninhadaUseCase)
        {
            _ninhadaUseCase = ninhadaUseCase;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var ninhada = await _ninhadaUseCase.GetByIdAsync(id);
                if (ninhada == null)
                {
                    return NotFound();
                }
                return Ok(ninhada);

            }
            catch (Exception ex)
            {
                // Retorna 500 se ocorrer um erro inesperado
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"Erro ao Buscar a matriz: {ex.Message}" });
            }

        }

        [HttpGet("/matriz/{id}")]
        public async Task<IActionResult> GetByMatrizIdAsync(int id)
        {
            try
            {
                var ninhada = await _ninhadaUseCase.GetByMatrizIdAsync(id);
                if (ninhada == null)
                {
                    return NotFound();
                }
                return Ok(ninhada);

            }
            catch (Exception ex)
            {
                // Retorna 500 se ocorrer um erro inesperado
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"Erro ao Buscar a matriz: {ex.Message}" });
            }

        }

        [HttpPost("")]
        public async Task<IActionResult> PostMatriz([FromBody] NinhadaDTO ninhada)
        {
            try
            {
                await _ninhadaUseCase.CreateNinhada(ninhada);
                if (ninhada != null)
                {
                    return Created();
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                // Retorna 500 se ocorrer um erro inesperado
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"Erro ao Criar a matriz: {ex.Message}" });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatriz([FromBody] NinhadaDTO ninhada, int id)
        {
            try
            {
                var matrizResponse = await _ninhadaUseCase.UpdateNinhada(ninhada, id);
                Console.WriteLine(matrizResponse);
                if (matrizResponse == null)
                {
                    return NotFound(new { Message = "Matriz não encontrada." });
                }

                return Ok(matrizResponse);
            }
            catch (Exception ex)
            {
                // Retorna 500 se ocorrer um erro inesperado
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"Erro ao atualizar a matriz: {ex.Message}" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatriz(int id)
        {
            try
            {
                var matrizResponse = await _ninhadaUseCase.DeleteNinhada(id);
                Console.WriteLine(matrizResponse);
                if (matrizResponse == null)
                {
                    return NotFound(new { Message = "Matriz não encontrada." });
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                // Retorna 500 se ocorrer um erro inesperado
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"Erro ao Deletar a matriz: {ex.Message}" });
            }
        }

    }

}

