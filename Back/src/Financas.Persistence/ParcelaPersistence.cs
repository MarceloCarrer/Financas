using System.Linq;
using System.Threading.Tasks;
using Financas.Domain;
using Financas.Persistence.Context;
using Financas.Persistence.Contract;
using Microsoft.EntityFrameworkCore;

namespace Financas.Persistence
{
    public class ParcelaPersistence : IParcelaPersistence
    {
        private readonly DataContext _context;

        public ParcelaPersistence(DataContext context)
        {
            _context = context;
        }
        
        //PARCELAS        
        public async Task<Parcela[]> GetAllParcelasByParceladoIdAsync(int parceladoId)
        {
            IQueryable<Parcela> query = _context.Parcelas;
            query = query.Where(pl => pl.ParceladoId == parceladoId) 
                         .AsNoTracking()
                         .OrderBy(pl => pl.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Parcela> GetParcelaByIdsAsync(int parceladoId, int parcelaId)
        {
            IQueryable<Parcela> query = _context.Parcelas;
            query = query.Where(pl => pl.ParceladoId == parceladoId && pl.Id == parcelaId)
                         .AsNoTracking()
                         .OrderBy(pl => pl.Id);

            return await query.FirstOrDefaultAsync();
        }
    }
}