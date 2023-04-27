using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Financas.Domain;

namespace Financas.Persistence.Contract
{
    public interface IFormaPagamentoPersistence
    {
        Task<FormaPagamento[]> GetAllFormaPagamentosAsync();
        Task<FormaPagamento[]> GetAllFormaPagamentosByNomeAsync(string nome);
        Task<FormaPagamento> GetFormaPagamentoByIdAsync(int id);
    }
}