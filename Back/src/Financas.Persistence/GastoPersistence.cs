using System.Linq;
using System.Threading.Tasks;
using Financas.Domain;
using Financas.Persistence.Context;
using Financas.Persistence.Contract;
using Microsoft.EntityFrameworkCore;

namespace Financas.Persistence
{
    public class GastoPersistence : IGastoPersistence
    {
        private readonly DataContext _context;

        public GastoPersistence(DataContext context)
        {
            _context = context;
        }

        //GASTOS
        public async Task<Gasto[]> GetAllGastosAsync()
        {
            IQueryable<Gasto> query = _context.Gastos
                        .Include(g => g.Categorias);
                
            query = query.AsNoTracking().OrderByDescending(gt => gt.DataCompra);

            return await query.ToArrayAsync();
        }

        public async Task<Gasto[]> GetAllGastosByLocalAsync(string local)
        {
            IQueryable<Gasto> query = _context.Gastos
                        .Include(g => g.Categorias);

            query = query.Where(gt => gt.Local.ToLower().Contains(local.ToLower()))
                         .AsNoTracking()
                         .OrderByDescending(gt => gt.DataCompra);

            return await query.ToArrayAsync();
        }

        public async Task<Gasto[]> GetAllGastosByMesAsync(int mes, int ano)
        {
            IQueryable<Gasto> query = _context.Gastos
                        .Include(g => g.Categorias);

            query = query.Where(gt => gt.DataCompra.Month == mes && gt.DataCompra.Year == ano) 
                         .AsNoTracking()
                         .OrderByDescending(gt => gt.DataCompra.Month)
                         .ThenByDescending(gt => gt.DataCompra.Year);

            return await query.ToArrayAsync();
        }

        public async Task<Gasto[]> GetAllGastosByAnoAsync(int ano)
        {
            IQueryable<Gasto> query = _context.Gastos
                        .Include(g => g.Categorias);

            query = query.Where(gt => gt.DataCompra.Year == ano) 
                         .AsNoTracking()
                         .OrderByDescending(gt => gt.DataCompra);

            return await query.ToArrayAsync();
        }

        public async Task<Gasto[]> GetAllGastosByCategoriaAsync(int categoriaId)
        {
            IQueryable<Gasto> query = _context.Gastos
                        .Include(g => g.Categorias);

            query = query.Where(gt => gt.CategoriaId == categoriaId) 
                         .AsNoTracking()
                         .OrderByDescending(gt => gt.DataCompra);

            return await query.ToArrayAsync();
        }
        
        public async Task<Gasto> GetGastoByIdAsync(int id)
        {
            IQueryable<Gasto> query = _context.Gastos
                        .Include(g => g.Categorias);
                        
            query = query.Where(gt => gt.Id == id)
                         .AsNoTracking()
                         .OrderBy(gt => gt.Id);

            return await query.FirstOrDefaultAsync();
        }
    }
}