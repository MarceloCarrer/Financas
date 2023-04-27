using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Financas.Application.Contracts;
using Financas.Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Financas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstabelecimentoController : Controller
    {
        private readonly IEstabelecimentoService _estabelecimentoService;

        public EstabelecimentoController(IEstabelecimentoService estabelecimentoService)
        {
            _estabelecimentoService = estabelecimentoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var estabelecimentos = await _estabelecimentoService.GetAllEstabelecimentosAsync();
                if (estabelecimentos == null)
                {
                    return NoContent();
                }
                return Ok(estabelecimentos);
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
                var estabelecimento = await _estabelecimentoService.GetEstabelecimentoByIdAsync(id);
                if (estabelecimento == null)
                {
                    return NoContent();
                }
                return Ok(estabelecimento);
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
                var estabelecimento = await _estabelecimentoService.GetAllEstabelecimentosByNomeAsync(nome);
                if (estabelecimento == null)
                {
                    return NoContent();
                }
                return Ok(estabelecimento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                                       $"Erro ao tentar recuperar registro. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(EstabelecimentoDto model)
        {
            try
            {
                var estabelecimento = await _estabelecimentoService.AddEstabelecimento(model);
                if (estabelecimento == null)
                {
                    return NoContent();
                }
                return Ok(estabelecimento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                                       $"Erro ao tentar adicionar registro. Erro: {ex.Message}");
            } 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, EstabelecimentoDto model)
        {
            try
            {
                var estabelecimento = await _estabelecimentoService.UpdateEstabelecimento(id, model);
                if (estabelecimento == null)
                {
                    return NoContent();
                }
                return Ok(estabelecimento);
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
                var estabelecimento = await _estabelecimentoService.GetEstabelecimentoByIdAsync(id);
                if (estabelecimento == null)
                {
                    return NoContent();
                }


                if (await _estabelecimentoService.DeleteEstabelecimento(id))
                {
                    return Ok(new {message = "Deletado."});
                }
                else
                {                    
                    throw new Exception("Erro ao tentar deletar registro.");
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