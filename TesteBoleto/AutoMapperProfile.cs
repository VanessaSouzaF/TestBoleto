// AutoMapperProfile.cs

using AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Banco, BancoDTO>().ReverseMap();
        CreateMap<Boleto, BoletoDTO>().ReverseMap();
    }
}
