using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Financas.Application.Contracts;
using Financas.Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Financas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class FormaPagamentoController : ControllerBase
    {
        private readonly IFormaPagamentoService _formaPagamentoService;
        public  FormaPagamentoController(IFormaPagamentoService formaPagamentoService)
        {
            _formaPagamentoService = formaPagamentoService;                      
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var formaPagamentos = await _formaPagamentoService.GetAllFormaPagamentosAsync();
                if (formaPagamentos == null)
                {
                    return NoContent();
                }
                return Ok(formaPagamentos);
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
                var formaPagamento = await _formaPagamentoService.GetFormaPagamentoByIdAsync(id);
                if (formaPagamento == null)
                {
                    return NoContent();
                }
                return Ok(formaPagamento);
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
                var formaPagamento = await _formaPagamentoService.GetAllFormaPagamentosByNomeAsync(nome);
                if (formaPagamento == null)
                {
                    return NoContent();
                }
                return Ok(formaPagamento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                                       $"Erro ao tentar recuperar registro. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(FormaPagamentoDto model)
        {
            try
            {
                var formaPagamento = await _formaPagamentoService.AddFormaPagamento(model);
                if (formaPagamento == null)
                {
                    return NoContent();
                }
                return Ok(formaPagamento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                                       $"Erro ao tentar adicionar registro. Erro: {ex.Message}");
            } 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, FormaPagamentoDto model)
        {
            try
            {
                var formaPagamento = await _formaPagamentoService.UpdateFormaPagamento(id, model);
                if (formaPagamento == null)
                {
                    return NoContent();
                }
                return Ok(formaPagamento);
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
                var formaPagamento = await _formaPagamentoService.GetFormaPagamentoByIdAsync(id);
                if (formaPagamento == null)
                {
                    return NoContent();
                }


                if (await _formaPagamentoService.DeleteFormaPagamento(id))
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