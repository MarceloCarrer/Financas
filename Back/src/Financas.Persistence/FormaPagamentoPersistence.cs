using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Financas.Domain;
using Financas.Persistence.Context;
using Financas.Persistence.Contract;
using Microsoft.EntityFrameworkCore;

namespace Financas.Persistence
{
    public class FormaPagamentoPersistence : IFormaPagamentoPersistence
    {
        private readonly DataContext _context;

        public FormaPagamentoPersistence(DataContext context)
        {
            _context = context;
        }

        public async Task<FormaPagamento[]> GetAllFormaPagamentosAsync()
        {
            IQueryable<FormaPagamento> query = _context.FormaPagamentos
                        .Include(c => c.Gastos)
                        .Include(c => c.Parcelados);

            query = query.AsNoTracking()
                         .OrderBy(ct => ct.Nome);

            return await query.ToArrayAsync();
        }

        public async Task<FormaPagamento[]> GetAllFormaPagamentosByNomeAsync(string nome)
        {
            IQueryable<FormaPagamento> query = _context.FormaPagamentos
                        .Include(c => c.Gastos)
                        .Include(c => c.Parcelados);

            query = query.Where(ct => ct.Nome.ToLower().Contains(nome.ToLower()))
                         .AsNoTracking()
                         .OrderBy(ct => ct.Nome);

            return await query.ToArrayAsync();
        }

        public async Task<FormaPagamento> GetFormaPagamentoByIdAsync(int id)
        {
            IQueryable<FormaPagamento> query = _context.FormaPagamentos
                        .Include(c => c.Gastos)
                        .Include(c => c.Parcelados);
                        
            query = query.Where(ct => ct.Id == id)
                         .AsNoTracking()
                         .OrderBy(ct => ct.Id);

            return await query.FirstOrDefaultAsync();
        }
    }
}