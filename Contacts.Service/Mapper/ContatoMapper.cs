using AutoMapper;
using Contacts.Domain.Models;
using Contacts.Domain.ModelsView;

namespace Contacts.Service.Mapper
{
    public class ContatoMapper : Profile
    {
        public ContatoMapper()
        {
            CreateMap<Contato, ContatoViewModel>()
                .ForPath(dest => dest.DDDNome, opt => opt.MapFrom(src => src.DDD.Nome))
                .ForPath(dest => dest.Ddd, opt => opt.MapFrom(src => src.DDD.Ddd));

            CreateMap<ContatoViewModel, Contato>()
                .ForMember(dest => dest.DDDId, opt => opt.Ignore())
                .ForPath(dest => dest.DDD.Nome, opt => opt.MapFrom(src => src.DDDNome))
                .ForPath(dest => dest.DDD.Ddd, opt => opt.MapFrom(src => src.Ddd));
        }
    }
}
