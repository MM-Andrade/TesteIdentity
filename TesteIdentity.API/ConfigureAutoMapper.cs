using AutoMapper;
using TesteIdentity.API.DTOs;
using TesteIdentity.API.Models;

namespace TesteIdentity.API
{
    public class ConfigureAutoMapper : Profile
    {
        public ConfigureAutoMapper()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Endereco, EnderecoDTO>().ReverseMap();
        }
    }
}
