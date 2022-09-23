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
    public class CategoriaController : ControllerBase
    {        
        private readonly ICategoriaService _categoriaService;
        public  CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;                      
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var categorias = await _categoriaService.GetAllCategoriasAsync();
                if (categorias == null)
                {
                    return NoContent();
                }
                return Ok(categorias);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                                       $"Erro ao tentar recuperar categorias. Erro: {ex.Message}");
            }
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var categoria = await _categoriaService.GetCategoriaByIdAsync(id);
                if (categoria == null)
                {
                    return NoContent();
                }
                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                                       $"Erro ao tentar recuperar categorias. Erro: {ex.Message}");
            }
        }

        [HttpGet("nome/{nome}")]
        public async Task<IActionResult> GetByNome(string nome)
        {
            try
            {
                var categoria = await _categoriaService.GetAllCategoriasByNomeAsync(nome);
                if (categoria == null)
                {
                    return NoContent();
                }
                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                                       $"Erro ao tentar recuperar categorias. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CategoriaDto model)
        {
            try
            {
                var categoria = await _categoriaService.AddCategoria(model);
                if (categoria == null)
                {
                    return NoContent();
                }
                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                                       $"Erro ao tentar adicionar categorias. Erro: {ex.Message}");
            } 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CategoriaDto model)
        {
            try
            {
                var categoria = await _categoriaService.UpdateCategoria(id, model);
                if (categoria == null)
                {
                    return NoContent();
                }
                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                                       $"Erro ao tentar atualizar categorias. Erro: {ex.Message}");
            } 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var categoria = await _categoriaService.GetCategoriaByIdAsync(id);
                if (categoria == null)
                {
                    return NoContent();
                }


                if (await _categoriaService.DeleteCategoria(id))
                {
                    return Ok(new {message = "Deletado."});
                }
                else
                {                    
                    throw new Exception("Erro ao tentar deletar categorias.");
                }
                
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                                       $"Erro ao tentar deletar categorias. Erro: {ex.Message}");
            } 
        }
    }
}
