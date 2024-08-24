using Microsoft.AspNetCore.Mvc;
using Pet.App.Entities.PgSQL;
using Pet.App.Gateways;
using Pet.Infrastructure.Data.Config;
using System;

namespace Pet.App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetController : ControllerBase
    {

            private readonly IRepositoryInterface _repositoryInterface;
            public PetController(IRepositoryInterface repositoryInterface)
            {
                _repositoryInterface = repositoryInterface;
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetByIdAsync(int id)
            {
                var matriz = await _repositoryInterface.GetByIdAsync(id);
                if (matriz != null)
                {
                  return Ok(matriz);
                }
                else
                {
                  return NoContent();
                }
            }


        }
    
}
