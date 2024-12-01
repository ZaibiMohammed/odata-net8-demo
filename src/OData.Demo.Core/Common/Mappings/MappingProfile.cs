using AutoMapper;
using OData.Demo.Core.Entities;
using OData.Demo.Core.Features.Clients.Models;

namespace OData.Demo.Core.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Client, ClientDto>();
        }
    }
}