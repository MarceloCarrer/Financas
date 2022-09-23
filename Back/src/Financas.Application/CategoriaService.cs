using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Financas.Application.Contracts;
using Financas.Application.Dtos;
using Financas.Domain;
using Financas.Persistence.Contract;
using Financas.Repository.Contract;

namespace Financas.Application
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IGeralPersistence _geralPersistence;
        private readonly ICategoriaPersistence _categoriaPersistence;
        private readonly IMapper _mapper;

        public CategoriaService(IGeralPersistence geralPersistence, ICategoriaPersistence categoriaPersistence, IMapper mapper)
        {
            _geralPersistence = geralPersistence;
            _categoriaPersistence = categoriaPersistence;
            _mapper = mapper;
        }

        public async Task<CategoriaDto> AddCategoria(CategoriaDto model)
        {
            try
            {
                var categoria = _mapper.Map<Categoria>(model);

                _geralPersistence.Add<Categoria>(categoria);

                if (await _geralPersistence.SaveChengesAsync())
                {
                    var retorno = await _categoriaPersistence.GetCategoriaByIdAsync(categoria.Id);

                    return _mapper.Map<CategoriaDto>(retorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CategoriaDto> UpdateCategoria(int id, CategoriaDto model)
        {
            try
            {
                var categoria = await _categoriaPersistence.GetCategoriaByIdAsync(id);
                if (categoria == null)
                {
                    return null;
                }

                model.Id = categoria.Id;

                _mapper.Map(model, categoria);
                
                _geralPersistence.Update<Categoria>(categoria);
                if (await _geralPersistence.SaveChengesAsync())
                {
                    var retorno = await _categoriaPersistence.GetCategoriaByIdAsync(categoria.Id);

                    return _mapper.Map<CategoriaDto>(retorno);
                }
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteCategoria(int id)
        {
            try
            {
                var categoria = await _categoriaPersistence.GetCategoriaByIdAsync(id);
                if (categoria == null)
                {
                    throw new Exception("Registro não encontrado.");
                }

                _geralPersistence.Delete(categoria);
                return await _geralPersistence.SaveChengesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CategoriaDto[]> GetAllCategoriasAsync()
        {
            try
            {
                var categorias = await _categoriaPersistence.GetAllCategoriasAsync();
                if (categorias == null)
                {
                    return null;                    
                }

                var resultado = _mapper.Map<CategoriaDto[]>(categorias);

                return resultado;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<CategoriaDto[]> GetAllCategoriasByNomeAsync(string nome)
        {
            try
            {
                var categorias = await _categoriaPersistence.GetAllCategoriasByNomeAsync(nome);
                if (categorias == null)
                {
                    return null;                    
                }

                var resultado = _mapper.Map<CategoriaDto[]>(categorias);

                return resultado;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<CategoriaDto> GetCategoriaByIdAsync(int id)
        {
            try
            {
                var categoria = await _categoriaPersistence.GetCategoriaByIdAsync(id);
                if (categoria == null)
                {
                    return null;                    
                }

                var resultado = _mapper.Map<CategoriaDto>(categoria);

                return resultado;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

       
    }
}