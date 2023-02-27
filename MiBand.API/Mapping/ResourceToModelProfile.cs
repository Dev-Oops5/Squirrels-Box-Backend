using AutoMapper;
using MiBand.API.Domain.Models;
using MiBand.API.Domain.Services.Communications;
using MiBand.API.Resources;

namespace MiBand.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveEmployeeResource, Employee>();

            CreateMap<SaveSessionResource, Session>();
            CreateMap<SaveUserResource, User>();
            CreateMap<SaveBoxResource, Box>();
            CreateMap<SaveSectionResource, Section>();
            CreateMap<SaveItemResource, Item>();
            CreateMap<SaveSpecResource, Spec>();
            CreateMap<SaveSharedResource, Shared>();
        }
    }
}
