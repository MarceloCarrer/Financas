using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Financas.Application.Dtos;

namespace Financas.Application.Contracts
{
    public interface IFormaPagamentoService
    {
        Task<FormaPagamentoDto>AddFormaPagamento(FormaPagamentoDto model);
        Task<FormaPagamentoDto> UpdateFormaPagamento(int id, FormaPagamentoDto model);
        Task<bool> DeleteFormaPagamento(int id);

        Task<FormaPagamentoDto[]> GetAllFormaPagamentosAsync();
        Task<FormaPagamentoDto[]> GetAllFormaPagamentosByNomeAsync(string nome);
        Task<FormaPagamentoDto> GetFormaPagamentoByIdAsync(int id);
    }
}