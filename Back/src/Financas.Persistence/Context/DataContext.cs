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
        public DbSet<Estabelecimento> Estabelecimentos { get; set; }
        public DbSet<FormaPagamento> FormaPagamentos { get; set; }
        public DbSet<Gasto> Gastos { get; set; }
        public DbSet<Parcelado> Parcelados { get; set; }
        public DbSet<Parcela> Parcelas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Categoria
            modelBuilder.Entity<Categoria>().HasData(new Categoria
            {
                Id = 1,
                Nome = "Mercado",
                DataCadastro = DateTime.Today
            });

            modelBuilder.Entity<Categoria>().HasData(new Categoria
            {
                Id = 2,
                Nome = "Farmácia",
                DataCadastro = DateTime.Today
            });

            modelBuilder.Entity<Categoria>().HasData(new Categoria
            {
                Id = 3,
                Nome = "Vestuário",
                DataCadastro = DateTime.Today
            });

            modelBuilder.Entity<Categoria>().HasData(new Categoria
            {
                Id = 4,
                Nome = "Eletrodoméstico",
                DataCadastro = DateTime.Today
            });

            modelBuilder.Entity<Categoria>().HasData(new Categoria
            {
                Id = 5,
                Nome = "Veículo",
                DataCadastro = DateTime.Today
            });

            modelBuilder.Entity<Categoria>().HasData(new Categoria
            {
                Id = 6,
                Nome = "Construção",
                DataCadastro = DateTime.Today
            });

            modelBuilder.Entity<Categoria>().HasData(new Categoria
            {
                Id = 7,
                Nome = "Cozinha",
                DataCadastro = DateTime.Today
            });

            modelBuilder.Entity<Categoria>().HasData(new Categoria
            {
                Id = 8,
                Nome = "Transporte",
                DataCadastro = DateTime.Today
            });

            modelBuilder.Entity<Categoria>().HasData(new Categoria
            {
                Id = 9,
                Nome = "Cama/Banho",
                DataCadastro = DateTime.Today
            });

            modelBuilder.Entity<Categoria>().HasData(new Categoria
            {
                Id = 10,
                Nome = "Academia",
                DataCadastro = DateTime.Today
            });

            /*
            modelBuilder.Entity<Categoria>().HasData(new Categoria
            {
                Id = 11,
                Nome = "Outro",
                DataCadastro = DateTime.Today
            });
            */

            //Forma Pagamento
            modelBuilder.Entity<FormaPagamento>().HasData(new FormaPagamento
            {
                Id = 1,
                Nome = "Cartão de Crédito",
                DataCadastro = DateTime.Today
            });

            modelBuilder.Entity<FormaPagamento>().HasData(new FormaPagamento
            {
                Id = 2,
                Nome = "Cartão de Débito",
                DataCadastro = DateTime.Today
            });

            modelBuilder.Entity<FormaPagamento>().HasData(new FormaPagamento
            {
                Id = 3,
                Nome = "Cartão Alimentação",
                DataCadastro = DateTime.Today
            });

            modelBuilder.Entity<FormaPagamento>().HasData(new FormaPagamento
            {
                Id = 4,
                Nome = "Dinheiro",
                DataCadastro = DateTime.Today
            });

            modelBuilder.Entity<FormaPagamento>().HasData(new FormaPagamento
            {
                Id = 5,
                Nome = "Pix",
                DataCadastro = DateTime.Today
            });
            
            modelBuilder.Entity<FormaPagamento>().HasData(new FormaPagamento
            {
                Id = 6,
                Nome = "Cheque",
                DataCadastro = DateTime.Today
            });            

            //Estabelecimento
            modelBuilder.Entity<Estabelecimento>().HasData(new Estabelecimento
            {
                Id = 1,
                Nome = "Zafari",
                Endereco = "Av. Juca Batista",
                Numero = 925,
                Bairro = "Ipanema",
                CEP = 91770001,
                Cidade = "Porto Alegre",
                UF = "RS",
                Foto = "image1.png",
                DataCadastro = DateTime.Today
            });

            /*
            modelBuilder.Entity<Estabelecimento>().HasData(new Estabelecimento
            {
                Id = 2,
                Nome = "Panvel",
                Endereco = "Av. Eduardo Prado",
                Numero = 1901,
                Bairro = "Cavalhada",
                CEP = 91751000,
                Cidade = "Porto Alegre",
                UF = "RS",
                Foto = "image2.png",
                DataCadastro = DateTime.Today
            })
            */
        }
    }
}