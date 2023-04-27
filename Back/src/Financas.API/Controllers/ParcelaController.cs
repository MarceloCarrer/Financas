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
    public class ParcelaController : ControllerBase
    {        
        private readonly IParcelaService _parcelaService;
        public  ParcelaController(IParcelaService parcelaService)
        {
            _parcelaService = parcelaService;                      
        }        
        
        [HttpGet("parceladoId/{parceladoId}")]
        public async Task<IActionResult> GetByParcelado(int parceladoId)
        {
            try
            {
                var parcela = await _parcelaService.GetAllParcelasByParceladoIdAsync(parceladoId);
                if (parcela == null)
                {
                    return NotFound("Nenhum registro encontrado.");
                }
                return Ok(parcela);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                                       $"Erro ao tentar recuperar registros. Erro: {ex.Message}");
            }
        }       

        [HttpPut("{parceladoId}")]
        public async Task<IActionResult> SaveParcelas(int parceladoId, ParcelaDto[] models)
        {
            try
            {
                var parcela = await _parcelaService.SaveParcelas(parceladoId, models);
                if (parcela == null)
                {
                    return NoContent();
                }
                return Ok(parcela);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                                       $"Erro ao tentar atualizar registro. Erro: {ex.Message}");
            } 
        }

        [HttpDelete("{parceladoId}/{parcelaId}")]
        public async Task<IActionResult> Delete(int parceladoId, int parcelaId)
        {
            try
            {
                var parcela = await _parcelaService.GetParcelaByIdsAsync(parceladoId, parcelaId);
                if (parcela == null)
                {
                    return NoContent();
                }

                if (await _parcelaService.DeletaParcelas(parcela.ParceladoId, parcela.Id))
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
