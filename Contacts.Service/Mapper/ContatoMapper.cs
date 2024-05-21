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
                //.ForPath(destino => destino.DDD., option => option.MapFrom(origem => origem.DDD.Nome))
                .ReverseMap();
        }
    }
}
