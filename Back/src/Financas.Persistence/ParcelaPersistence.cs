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
        public async Task<Parcela[]> GetAllParcelasAsync()
        {
            IQueryable<Parcela> query = _context.Parcelas;
            query = query.AsNoTracking().OrderBy(pl => pl.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Parcela[]> GetAllParcelasByParceladosAsync(Parcelado ParceladoId)
        {
            IQueryable<Parcela> query = _context.Parcelas;
            query = query.Where(pl => pl.ParceladoId == ParceladoId.Id) 
                         .AsNoTracking()
                         .OrderBy(pl => pl.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Parcela> GetParcelasByIdAsync(int id)
        {
            IQueryable<Parcela> query = _context.Parcelas;
            query = query.Where(pl => pl.Id == id)
                         .AsNoTracking()
                         .OrderBy(pl => pl.Id);

            return await query.FirstOrDefaultAsync();
        }
    }
}