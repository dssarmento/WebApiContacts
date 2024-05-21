using AutoMapper;
using Contacts.Domain.Models;
using Contacts.Domain.ModelsView;

namespace Contacts.Service.Mapper
{
    public class DDDMapper : Profile
    {
        public DDDMapper()
        {
            CreateMap<DDD, DDDViewModel>().ReverseMap();
        }
    }
}
