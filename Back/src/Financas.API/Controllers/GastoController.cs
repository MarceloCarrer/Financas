using Microsoft.AspNetCore.Mvc;
using Financas.Application.Contracts;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;
using Financas.Application.Dtos;

namespace Financas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GastoController : ControllerBase
    {        
        private readonly IGastoService _gastoService;
        public  GastoController(IGastoService gastoService)
        {
            _gastoService = gastoService;                      
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var gastos = await _gastoService.GetAllGastosAsync();
                if (gastos == null)
                {
                    return NoContent();
                }

                return Ok(gastos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                                       $"Erro ao tentar recuperar registros. Erro: {ex.Message}");
            }
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var gasto = await _gastoService.GetGastoByIdAsync(id);
                if (gasto == null)
                {
                    return NoContent();
                }
                return Ok(gasto);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                                       $"Erro ao tentar recuperar registro. Erro: {ex.Message}");
            }
        }

        [HttpGet("local/{local}")]
        public async Task<IActionResult> GetByLocal(string local)
        {
            try
            {
                var gasto = await _gastoService.GetAllGastosByLocalAsync(local);
                if (gasto == null)
                {
                    return NoContent();
                }
                return Ok(gasto);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                                       $"Erro ao tentar recuperar registros. Erro: {ex.Message}");
            }
        }

        [HttpGet("mes/{mes}/ano/{ano}")]
        public async Task<IActionResult> GetByMes(int mes, int ano)
        {
            try
            {
                var gasto = await _gastoService.GetAllGastosByMesAsync(mes, ano);
                if (gasto == null)
                {
                    return NoContent();
                }
                return Ok(gasto);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                                       $"Erro ao tentar recuperar registros. Erro: {ex.Message}");
            }
        }

        [HttpGet("ano/{ano}")]
        public async Task<IActionResult> GetByAno(int ano)
        {
            try
            {
                var gasto = await _gastoService.GetAllGastosByAnoAsync(ano);
                if (gasto == null)
                {
                    return NoContent();
                }
                return Ok(gasto);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                                       $"Erro ao tentar recuperar registros. Erro: {ex.Message}");
            }
        }

        [HttpGet("categoriaId/{categoriaId}")]
        public async Task<IActionResult> GetByCategoria(int categoriaId)
        {
            try
            {
                var gasto = await _gastoService.GetAllGastosByCategoriaAsync(categoriaId);
                if (gasto == null)
                {
                    return NoContent();
                }
                return Ok(gasto);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                                       $"Erro ao tentar recuperar registros. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(GastoDto model)
        {
            try
            {
                var gasto = await _gastoService.AddGasto(model);
                if (gasto == null)
                {
                    return NoContent();
                }
                return Ok(gasto);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                                       $"Erro ao tentar adicionar registro. Erro: {ex.Message}");
            } 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, GastoDto model)
        {
            try
            {
                var gasto = await _gastoService.UpdateGasto(id, model);
                if (gasto == null)
                {
                    return NoContent();
                }
                return Ok(gasto);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                                       $"Erro ao tentar atualizar registro. Erro: {ex.Message}");
            } 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var categoria = await _gastoService.GetGastoByIdAsync(id);
                if (categoria == null)
                {
                    return NoContent();
                }

                if (await _gastoService.DeleteGasto(id))
                {
                    return Ok(new {message = "Deletado."});
                }
                else
                {                    
                    throw new Exception("Erro ao tentar adicionar registro.");
                }
                
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                                       $"Erro ao tentar deletar registro. Erro: {ex.Message}");
            } 
        }
    }
}
