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
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioUseCase _usuarioUseCase;
        private readonly NinhadaUseCase _ninhadaUseCase;

        public UsuarioController(UsuarioUseCase usuarioUseCase)
        {
            _usuarioUseCase = usuarioUseCase;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var matriz = await _usuarioUseCase.GetByIdAsync(id);
                if (matriz == null)
                {
                    return NotFound();
                }
                return Ok(matriz);

            }
            catch (Exception ex)
            {
                // Retorna 500 se ocorrer um erro inesperado
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"Erro ao Buscar o Usario: {ex.Message}" });
            }

        }

        [HttpPost("")]
        public async Task<IActionResult> PostUsuario([FromBody] UsuarioDTO usuarioDTO)
        {
            try
            {
               var usuariozResponse = await _usuarioUseCase.CreateUsuario(usuarioDTO);
                if (usuariozResponse != null)
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
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"Erro ao Criar o Usario: {ex.Message}" });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario([FromBody] UsuarioDTO usuarioDTO, int id)
        {
            try
            {
                var usuariozResponse = await _usuarioUseCase.UpdateUsuario(usuarioDTO, id);
                if (usuariozResponse == null)
                {
                    return NotFound(new { Message = "Usario não encontrado." });
                }

                return Ok(usuariozResponse);
            }
            catch (Exception ex)
            {
                // Retorna 500 se ocorrer um erro inesperado
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"Erro ao atualizar o Usario: {ex.Message}" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            try
            {
                var usuariozResponse = await _usuarioUseCase.DeleteUsuario(id);

                if (usuariozResponse == null)
                {
                    return NotFound(new { Message = "Usario não encontrada." });
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                // Retorna 500 se ocorrer um erro inesperado
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"Erro ao Deletar a Usario: {ex.Message}" });
            }
        }

    }

}

