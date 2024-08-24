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
    public class PetController : ControllerBase
    {
        private readonly MatrizUseCase _matrizUseCase;

        public PetController(MatrizUseCase matrizUseCase)
        {
            _matrizUseCase = matrizUseCase;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var matriz = await _matrizUseCase.GetByIdAsync(id);
            if (matriz != null)
            {
                return Ok(matriz);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> PostMatriz([FromBody] MatrizDTO matriz)
        {
            await _matrizUseCase.CreateMatriz(matriz);
            if (matriz != null)
            {
                return Created();
            }
            else
            {
                return NoContent();
            }
        }

    }

}
