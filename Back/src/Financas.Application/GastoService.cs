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
    public class GastoService : IGastoService
    {
        private readonly IGeralPersistence _geralPersistence;
        private readonly IGastoPersistence _gastoPersistence;
        private readonly IMapper _mapper;

        public GastoService(IGeralPersistence geralPersistence, IGastoPersistence gastoPersistence, IMapper mapper)
        {
            _geralPersistence = geralPersistence;
            _gastoPersistence = gastoPersistence;
            _mapper = mapper;
        }

        public async Task<GastoDto> AddGasto(GastoDto model)
        {
            try
            {
                var gasto = _mapper.Map<Gasto>(model);

                _geralPersistence.Add<Gasto>(gasto);

                if (await _geralPersistence.SaveChengesAsync())
                {
                    var retorno =  await _gastoPersistence.GetGastoByIdAsync(gasto.Id);

                    return _mapper.Map<GastoDto>(retorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GastoDto> UpdateGasto(int id, GastoDto model)
        {
            try
            {
                var gasto = await _gastoPersistence.GetGastoByIdAsync(id);
                if (gasto == null)
                {
                    return null;
                }

                model.Id = gasto.Id;

                _mapper.Map(model, gasto);
                
                _geralPersistence.Update<Gasto>(gasto);
                if (await _geralPersistence.SaveChengesAsync())
                {
                    var retorno =  await _gastoPersistence.GetGastoByIdAsync(gasto.Id);

                    return _mapper.Map<GastoDto>(retorno);
                }
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteGasto(int id)
        {
            try
            {
                var gasto = await _gastoPersistence.GetGastoByIdAsync(id);
                if (gasto == null)
                {
                    throw new Exception("Registro não encontrado.");
                }

                _geralPersistence.Delete(gasto);
                return await _geralPersistence.SaveChengesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GastoDto[]> GetAllGastosAsync()
        {
            try
            {
                var gastos = await _gastoPersistence.GetAllGastosAsync();
                if (gastos == null)
                {
                    return null;                    
                }

                var resultado = _mapper.Map<GastoDto[]>(gastos);

                return resultado;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<GastoDto[]> GetAllGastosByLocalAsync(string local)
        {
            try
            {
                var gastos = await _gastoPersistence.GetAllGastosByLocalAsync(local);
                if (gastos == null)
                {
                    return null;                    
                }

                var resultado = _mapper.Map<GastoDto[]>(gastos);

                return resultado;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }
        
        public async Task<GastoDto[]> GetAllGastosByMesAsync(int mes, int ano)
        {
            try
            {
                var gastos = await _gastoPersistence.GetAllGastosByMesAsync(mes, ano);
                if (gastos == null)
                {
                    return null;                    
                }

                var resultado = _mapper.Map<GastoDto[]>(gastos);

                return resultado;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<GastoDto[]> GetAllGastosByAnoAsync(int ano)
        {
            try
            {
                var gastos = await _gastoPersistence.GetAllGastosByAnoAsync(ano);
                if (gastos == null)
                {
                    return null;                    
                }

                var resultado = _mapper.Map<GastoDto[]>(gastos);

                return resultado;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<GastoDto[]> GetAllGastosByCategoriaAsync(int categoriaId)
        {
            try
            {
                var gastos = await _gastoPersistence.GetAllGastosByCategoriaAsync(categoriaId);
                if (gastos == null)
                {
                    return null;                    
                }

                var resultado = _mapper.Map<GastoDto[]>(gastos);

                return resultado;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<GastoDto> GetGastoByIdAsync(int id)
        {
            try
            {
                var gasto = await _gastoPersistence.GetGastoByIdAsync(id);
                if (gasto == null)
                {
                    return null;                    
                }

                var resultado = _mapper.Map<GastoDto>(gasto);

                return resultado;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

    }
}