using AutoMapper;

namespace TesteBoleto.TesteBoleto.Mappings
{
    public class EntiDtoProfile : Profile
    {
        public EntiDtoProfile()
        {
            CreateMap<Boleto, BoletoDTO>().ReverseMap();
            CreateMap<Banco, BancoDTO>().ReverseMap();
        }
    }
}