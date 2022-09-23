using AutoMapper;
using Financas.Application.Dtos;
using Financas.Domain;

namespace Financas.Application.Helpers
{
    public class FinancasProfile : Profile
    {
        public FinancasProfile()
        {
            CreateMap<Gasto, GastoDto>().ReverseMap();
            CreateMap<Categoria, CategoriaDto>().ReverseMap();
            CreateMap<Parcelado, ParceladoDto>().ReverseMap();
        }
    }
}