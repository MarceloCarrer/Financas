using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Financas.Domain;
using Microsoft.EntityFrameworkCore;

namespace Financas.Persistence.Context
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Gasto> Gastos { get; set; }
        public DbSet<Parcelado> Parcelados { get; set; }
        public DbSet<Parcela> Parcelas { get; set; }


    }
}