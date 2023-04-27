using System;
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
    public class ParcelaService : IParcelaService
    {
        private readonly IGeralPersistence _geralPersistence;
        private readonly IParcelaPersistence _parcelaPersistence;
        private readonly IMapper _mapper;

        public ParcelaService(IGeralPersistence geralPersistence, IParcelaPersistence parcelaPersistence, IMapper mapper)
        {
            _geralPersistence = geralPersistence;
            _parcelaPersistence = parcelaPersistence;
            _mapper = mapper;
        }
        
        public async Task AddParcela(int parceladoId, ParcelaDto model)
        {
            try
            {
                var parcela = _mapper.Map<Parcela>(model);

                parcela.ParceladoId = parceladoId;

                _geralPersistence.Add<Parcela>(parcela);

                await _geralPersistence.SaveChengesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ParcelaDto[]> SaveParcelas(int parceladoId, ParcelaDto[] models)
        {
            try
            {
                var parcelas = await _parcelaPersistence.GetAllParcelasByParceladoIdAsync(parceladoId);
                if (parcelas == null)
                {
                    return null;
                }
                
                foreach (var model in models)
                {

                    if (model.Id == 0)
                    {
                        await AddParcela(parceladoId, model);
                    }
                    else
                    {
                        var parcela = parcelas.FirstOrDefault(parcela => parcela.Id == model.Id);

                        model.ParceladoId = parceladoId;

                        _mapper.Map(model, parcela);

                        _geralPersistence.Update<Parcela>(parcela);

                        await _geralPersistence.SaveChengesAsync();
                    }
                }

                var retorno =  await _parcelaPersistence.GetAllParcelasByParceladoIdAsync(parceladoId);

                return _mapper.Map<ParcelaDto[]>(retorno);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeletaParcelas(int parceladoId, int parcelaId)
        {
            try
            {
                var parcela = await _parcelaPersistence.GetParcelaByIdsAsync(parceladoId, parcelaId);
                if (parcela == null)
                {
                    throw new Exception("Registro não encontrado.");
                }

                _geralPersistence.Delete(parcela);
                return await _geralPersistence.SaveChengesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }     

        public async Task<ParcelaDto[]> GetAllParcelasByParceladoIdAsync(int parceladoId)
        {
            try
            {
                var parcelas = await _parcelaPersistence.GetAllParcelasByParceladoIdAsync(parceladoId);
                if (parcelas == null)
                {
                    return null;                    
                }

                var resultado = _mapper.Map<ParcelaDto[]>(parcelas);

                return resultado;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<ParcelaDto> GetParcelaByIdsAsync(int parceladoId, int parcelaId)
        {
            try
            {
                var parcela = await _parcelaPersistence.GetParcelaByIdsAsync(parceladoId, parcelaId);
                if (parcela == null)
                {
                    return null;                    
                }

                var resultado = _mapper.Map<ParcelaDto>(parcela);

                return resultado;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        
    }
}