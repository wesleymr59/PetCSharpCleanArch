﻿using Microsoft.AspNetCore.Mvc;
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
        private readonly NinhadaUseCase _ninhadaUseCase;

        public PetController(MatrizUseCase matrizUseCase, NinhadaUseCase ninhadaUseCase)
        {
            _matrizUseCase = matrizUseCase;
            _ninhadaUseCase = ninhadaUseCase;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var matriz = await _matrizUseCase.GetByIdAsync(id);
                if (matriz == null)
                {
                    return NotFound();
                }
                return Ok(matriz);

            }
            catch (Exception ex)
            {
                // Retorna 500 se ocorrer um erro inesperado
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"Erro ao Buscar a matriz: {ex.Message}" });
            }

        }

        [HttpPost("")]
        public async Task<IActionResult> PostMatriz([FromBody] MatrizDTO matriz)
        {
            try
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
            catch (Exception ex)
            {
                // Retorna 500 se ocorrer um erro inesperado
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"Erro ao Criar a matriz: {ex.Message}" });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatriz([FromBody] MatrizDTO matriz, int id)
        {
            try
            {
                var matrizResponse = await _matrizUseCase.UpdateMatriz(matriz, id);
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
                var matrizResponse = await _matrizUseCase.DeleteMatriz(id);
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

