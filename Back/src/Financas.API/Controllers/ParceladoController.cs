using Financas.Domain;
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
    public class ParceladoController : ControllerBase
    {        
        private readonly IParceladoService _parceladoService;
        public  ParceladoController(IParceladoService parceladoService)
        {
            _parceladoService = parceladoService;                      
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var parcelados = await _parceladoService.GetAllParceladosAsync();
                if (parcelados == null)
                {
                    return NotFound("Nenhum registro encontrado.");
                }
                return Ok(parcelados);
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
                var parcelado = await _parceladoService.GetParceladoByIdAsync(id);
                if (parcelado == null)
                {
                    return NotFound("Nenhum registro encontrado.");
                }
                return Ok(parcelado);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                                       $"Erro ao tentar recuperar registro. Erro: {ex.Message}");
            }
        }

        [HttpGet("nome/{nome}")]
        public async Task<IActionResult> GetByNome(string nome)
        {
            try
            {
                var parcelado = await _parceladoService.GetAllParceladosByNomeAsync(nome);
                if (parcelado == null)
                {
                    return NotFound("Nenhum registro encontrado.");
                }
                return Ok(parcelado);
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
                var parcelado = await _parceladoService.GetAllParceladosByMesAsync(mes, ano);
                if (parcelado == null)
                {
                    return NotFound("Nenhum registro encontrado.");
                }
                return Ok(parcelado);
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
                var parcelado = await _parceladoService.GetAllParceladosByAnoAsync(ano);
                if (parcelado == null)
                {
                    return NotFound("Nenhum registro encontrado.");
                }
                return Ok(parcelado);
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
                var parcelado = await _parceladoService.GetAllParceladosByCategoriaAsync(categoriaId);
                if (parcelado == null)
                {
                    return NotFound("Nenhum registro encontrado.");
                }
                return Ok(parcelado);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                                       $"Erro ao tentar recuperar registros. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ParceladoDto model)
        {
            try
            {
                var parcelado = await _parceladoService.AddParcelado(model);
                if (parcelado == null)
                {
                    return NoContent();
                }
                return Ok(parcelado);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                                       $"Erro ao tentar adicionar registro. Erro: {ex.Message}");
            } 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ParceladoDto model)
        {
            try
            {
                var parcelado = await _parceladoService.UpdateParcelado(id, model);
                if (parcelado == null)
                {
                    return NoContent();
                }
                return Ok(parcelado);
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
                var categoria = await _parceladoService.GetParceladoByIdAsync(id);
                if (categoria == null)
                {
                    return NoContent();
                }

                if (await _parceladoService.DeleteParcelado(id))
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
