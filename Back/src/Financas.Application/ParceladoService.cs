using System;
using System.Threading.Tasks;
using AutoMapper;
using Financas.Application.Contracts;
using Financas.Application.Dtos;
using Financas.Domain;
using Financas.Persistence.Contract;
using Financas.Repository.Contract;

namespace Financas.Application
{
    public class ParceladoService : IParceladoService
    {
        private readonly IGeralPersistence _geralPersistence;
        private readonly IParceladoPersistence _parceladoPersistence;
        private readonly IMapper _mapper;

        public ParceladoService(IGeralPersistence geralPersistence, IParceladoPersistence parceladoPersistence, IMapper mapper)
        {
            _geralPersistence = geralPersistence;
            _parceladoPersistence = parceladoPersistence;
            _mapper = mapper;
        }
        
        public async Task<ParceladoDto> AddParcelado(ParceladoDto model)
        {
            try
            {
                var parcelado = _mapper.Map<Parcelado>(model);

                _geralPersistence.Add<Parcelado>(parcelado);

                if (await _geralPersistence.SaveChengesAsync())
                {
                    var retorno = await _parceladoPersistence.GetParceladoByIdAsync(parcelado.Id);

                    return _mapper.Map<ParceladoDto>(retorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ParceladoDto> UpdateParcelado(int id, ParceladoDto model)
        {
            try
            {
                var parcelado = await _parceladoPersistence.GetParceladoByIdAsync(id);
                if (parcelado == null)
                {
                    return null;
                }

                model.Id = parcelado.Id;

                _mapper.Map(model, parcelado);
                
                _geralPersistence.Update<Parcelado>(parcelado);
                if (await _geralPersistence.SaveChengesAsync())
                {
                    var retorno =  await _parceladoPersistence.GetParceladoByIdAsync(parcelado.Id);

                    return _mapper.Map<ParceladoDto>(retorno);
                }
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteParcelado(int id)
        {
            try
            {
                var parcelado = await _parceladoPersistence.GetParceladoByIdAsync(id);
                if (parcelado == null)
                {
                    throw new Exception("Registro não encontrado.");
                }

                _geralPersistence.Delete(parcelado);
                return await _geralPersistence.SaveChengesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ParceladoDto[]> GetAllParceladosAsync()
        {
            try
            {
                var parcelados = await _parceladoPersistence.GetAllParceladosAsync();
                if (parcelados == null)
                {
                    return null;                    
                }

                var resultado = _mapper.Map<ParceladoDto[]>(parcelados);

                return resultado;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<ParceladoDto[]> GetAllParceladosByAnoAsync(int ano)
        {
            try
            {
                var parcelados = await _parceladoPersistence.GetAllParceladosByAnoAsync(ano);
                if (parcelados == null)
                {
                    return null;                    
                }

                var resultado = _mapper.Map<ParceladoDto[]>(parcelados);

                return resultado;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<ParceladoDto[]> GetAllParceladosByCategoriaAsync(int categoriaId)
        {
            try
            {
                var parcelados = await _parceladoPersistence.GetAllParceladosByCategoriaAsync(categoriaId);
                if (parcelados == null)
                {
                    return null;                    
                }

                var resultado = _mapper.Map<ParceladoDto[]>(parcelados);

                return resultado;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<ParceladoDto[]> GetAllParceladosByMesAsync(int mes, int ano)
        {
            try
            {
                var parcelados = await _parceladoPersistence.GetAllParceladosByMesAsync(mes, ano);
                if (parcelados == null)
                {
                    return null;                    
                }

                var resultado = _mapper.Map<ParceladoDto[]>(parcelados);

                return resultado;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<ParceladoDto[]> GetAllParceladosByNomeAsync(string nome)
        {
            try
            {
                var parcelados = await _parceladoPersistence.GetAllParceladosByNomeAsync(nome);
                if (parcelados == null)
                {
                    return null;                    
                }

                var resultado = _mapper.Map<ParceladoDto[]>(parcelados);

                return resultado;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<ParceladoDto> GetParceladoByIdAsync(int id)
        {
            try
            {
                var parcelado = await _parceladoPersistence.GetParceladoByIdAsync(id);
                if (parcelado == null)
                {
                    return null;                    
                }

                var resultado = _mapper.Map<ParceladoDto>(parcelado);

                return resultado;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }
    }
}