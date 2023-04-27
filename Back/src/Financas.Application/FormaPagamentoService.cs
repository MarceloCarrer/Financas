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
    public class FormaPagamentoService : IFormaPagamentoService
    {
        private readonly IGeralPersistence _geralPersistence;
        private readonly IFormaPagamentoPersistence _formaPagamentoPersistence;
        private readonly IMapper _mapper;

        public FormaPagamentoService(IGeralPersistence geralPersistence, IFormaPagamentoPersistence formaPagamentoPersistence, IMapper mapper)
        {
            _geralPersistence = geralPersistence;
            _formaPagamentoPersistence = formaPagamentoPersistence;
            _mapper = mapper;
        }

        public async Task<FormaPagamentoDto> AddFormaPagamento(FormaPagamentoDto model)
        {
            try
            {
                var formaPagamento = _mapper.Map<FormaPagamento>(model);

                _geralPersistence.Add<FormaPagamento>(formaPagamento);

                if (await _geralPersistence.SaveChengesAsync())
                {
                    var retorno = await _formaPagamentoPersistence.GetFormaPagamentoByIdAsync(formaPagamento.Id);

                    return _mapper.Map<FormaPagamentoDto>(retorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<FormaPagamentoDto> UpdateFormaPagamento(int id, FormaPagamentoDto model)
        {
            try
            {
                var formaPagamento = await _formaPagamentoPersistence.GetFormaPagamentoByIdAsync(id);
                if (formaPagamento == null)
                {
                    return null;
                }

                model.Id = formaPagamento.Id;

                _mapper.Map(model, formaPagamento);
                
                _geralPersistence.Update<FormaPagamento>(formaPagamento);
                if (await _geralPersistence.SaveChengesAsync())
                {
                    var retorno = await _formaPagamentoPersistence.GetFormaPagamentoByIdAsync(formaPagamento.Id);

                    return _mapper.Map<FormaPagamentoDto>(retorno);
                }
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteFormaPagamento(int id)
        {
            try
            {
                var formaPagamento = await _formaPagamentoPersistence.GetFormaPagamentoByIdAsync(id);
                if (formaPagamento == null)
                {
                    throw new Exception("Registro não encontrado.");
                }

                _geralPersistence.Delete(formaPagamento);
                return await _geralPersistence.SaveChengesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<FormaPagamentoDto[]> GetAllFormaPagamentosAsync()
        {
            try
            {
                var formaPagamentos = await _formaPagamentoPersistence.GetAllFormaPagamentosAsync();
                if (formaPagamentos == null)
                {
                    return null;                    
                }

                var resultado = _mapper.Map<FormaPagamentoDto[]>(formaPagamentos);

                return resultado;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<FormaPagamentoDto[]> GetAllFormaPagamentosByNomeAsync(string nome)
        {
            try
            {
                var formaPagamentos = await _formaPagamentoPersistence.GetAllFormaPagamentosByNomeAsync(nome);
                if (formaPagamentos == null)
                {
                    return null;                    
                }

                var resultado = _mapper.Map<FormaPagamentoDto[]>(formaPagamentos);

                return resultado;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<FormaPagamentoDto> GetFormaPagamentoByIdAsync(int id)
        {
            try
            {
                var formaPagamento = await _formaPagamentoPersistence.GetFormaPagamentoByIdAsync(id);
                if (formaPagamento == null)
                {
                    return null;                    
                }

                var resultado = _mapper.Map<FormaPagamentoDto>(formaPagamento);

                return resultado;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }
    }
}