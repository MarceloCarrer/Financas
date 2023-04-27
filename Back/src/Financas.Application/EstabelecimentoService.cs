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
    public class EstabelecimentoService : IEstabelecimentoService
    {
        private readonly IGeralPersistence _geralPersistence;
        private readonly IEstabelecimentoPersistence _estabelecimentoPersistence;
        private readonly IMapper _mapper;

        public EstabelecimentoService(IGeralPersistence geralPersistence, IEstabelecimentoPersistence estabelecimentoPersistence, IMapper mapper)
        {
            _geralPersistence = geralPersistence;
            _estabelecimentoPersistence = estabelecimentoPersistence;
            _mapper = mapper;
        }

        public async Task<EstabelecimentoDto> AddEstabelecimento(EstabelecimentoDto model)
        {
            try
            {
                var estabelecimento = _mapper.Map<Estabelecimento>(model);

                _geralPersistence.Add<Estabelecimento>(estabelecimento);

                if (await _geralPersistence.SaveChengesAsync())
                {
                    var retorno = await _estabelecimentoPersistence.GetEstabelecimentoByIdAsync(estabelecimento.Id);

                    return _mapper.Map<EstabelecimentoDto>(retorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EstabelecimentoDto> UpdateEstabelecimento(int id, EstabelecimentoDto model)
        {
            try
            {
                var estabelecimento = await _estabelecimentoPersistence.GetEstabelecimentoByIdAsync(id);
                if (estabelecimento == null)
                {
                    return null;
                }

                model.Id = estabelecimento.Id;

                _mapper.Map(model, estabelecimento);
                
                _geralPersistence.Update<Estabelecimento>(estabelecimento);
                if (await _geralPersistence.SaveChengesAsync())
                {
                    var retorno = await _estabelecimentoPersistence.GetEstabelecimentoByIdAsync(estabelecimento.Id);

                    return _mapper.Map<EstabelecimentoDto>(retorno);
                }
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEstabelecimento(int id)
        {
            try
            {
                var estabelecimento = await _estabelecimentoPersistence.GetEstabelecimentoByIdAsync(id);
                if (estabelecimento == null)
                {
                    throw new Exception("Registro não encontrado.");
                }

                _geralPersistence.Delete(estabelecimento);
                return await _geralPersistence.SaveChengesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EstabelecimentoDto[]> GetAllEstabelecimentosAsync()
        {
            try
            {
                var estabelecimentos = await _estabelecimentoPersistence.GetAllEstabelecimentosAsync();
                if (estabelecimentos == null)
                {
                    return null;                    
                }

                var resultado = _mapper.Map<EstabelecimentoDto[]>(estabelecimentos);

                return resultado;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<EstabelecimentoDto[]> GetAllEstabelecimentosByNomeAsync(string nome)
        {
            try
            {
                var estabelecimentos = await _estabelecimentoPersistence.GetAllEstabelecimentosByNomeAsync(nome);
                if (estabelecimentos == null)
                {
                    return null;                    
                }

                var resultado = _mapper.Map<EstabelecimentoDto[]>(estabelecimentos);

                return resultado;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<EstabelecimentoDto> GetEstabelecimentoByIdAsync(int id)
        {
            try
            {
                var estabelecimento = await _estabelecimentoPersistence.GetEstabelecimentoByIdAsync(id);
                if (estabelecimento == null)
                {
                    return null;                    
                }

                var resultado = _mapper.Map<EstabelecimentoDto>(estabelecimento);

                return resultado;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }
    }
}