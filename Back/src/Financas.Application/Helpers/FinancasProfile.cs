using AutoMapper;
using Financas.Application.Dtos;
using Financas.Domain;

namespace Financas.Application.Helpers
{
    public class FinancasProfile : Profile
    {
        public FinancasProfile()
        {
            CreateMap<Categoria, CategoriaDto>().ReverseMap();
            CreateMap<FormaPagamento, FormaPagamentoDto>().ReverseMap();
            CreateMap<Estabelecimento, EstabelecimentoDto>().ReverseMap();
            CreateMap<Gasto, GastoDto>().ReverseMap();
            CreateMap<Parcelado, ParceladoDto>().ReverseMap();
            CreateMap<Parcela, ParcelaDto>().ReverseMap();
        }
    }
}