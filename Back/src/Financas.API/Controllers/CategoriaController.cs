using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Financas.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Financas.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {       
        public IEnumerable<Categoria> _categoria = new Categoria[]{
                new Categoria() {
                    CategoriaId = 1,
                    Nome = "Mercado",
                    DataCadastro = DateTime.Today
                },
                new Categoria() {
                    CategoriaId = 2,
                    Nome = "Farmácia",
                    DataCadastro = DateTime.Today
                }
            };

        public  CategoriaController()
        {
            
        }

        [HttpGet]
        public IEnumerable<Categoria> Get()
        {
            return _categoria;            
        }

        [HttpGet("{id}")]
        public IEnumerable<Categoria> GetById(int id)
        {
            return _categoria.Where(categoria => categoria.CategoriaId == id);            
        }
    }
}
