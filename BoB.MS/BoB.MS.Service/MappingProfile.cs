using AutoMapper;
using BoB.MS.Domain.Model;
using BoB.MS.Repository.Model;

namespace BoB.MS.Service
{
    public class MappingProfile
        : Profile
    {
        public MappingProfile()
        {
            CreateMap<Client, ClientDto>().ReverseMap();
        }
    }
}
