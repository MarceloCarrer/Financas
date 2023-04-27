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
    public class EstabelecimentoPersistence : IEstabelecimentoPersistence
    {
        private readonly DataContext _context;

        public EstabelecimentoPersistence(DataContext context)
        {
            _context = context;
        }

        public async Task<Estabelecimento[]> GetAllEstabelecimentosAsync()
        {
            IQueryable<Estabelecimento> query = _context.Estabelecimentos
                        .Include(c => c.Gastos)
                        .Include(c => c.Parcelados);

            query = query.AsNoTracking()
                         .OrderBy(ct => ct.Nome);

            return await query.ToArrayAsync();
        }

        public async Task<Estabelecimento[]> GetAllEstabelecimentosByNomeAsync(string nome)
        {
            IQueryable<Estabelecimento> query = _context.Estabelecimentos
                        .Include(c => c.Gastos)
                        .Include(c => c.Parcelados);

            query = query.Where(ct => ct.Nome.ToLower().Contains(nome.ToLower()))
                         .AsNoTracking()
                         .OrderBy(ct => ct.Nome);

            return await query.ToArrayAsync();
        }

        public async Task<Estabelecimento> GetEstabelecimentoByIdAsync(int id)
        {
            IQueryable<Estabelecimento> query = _context.Estabelecimentos
                        .Include(c => c.Gastos)
                        .Include(c => c.Parcelados);
                        
            query = query.Where(ct => ct.Id == id)
                         .AsNoTracking()
                         .OrderBy(ct => ct.Id);

            return await query.FirstOrDefaultAsync();
        }
    }
}