using AutoMapper;
using MiBand.API.Domain.Models;
using MiBand.API.Domain.Services.Communications;
using MiBand.API.Resources;

namespace MiBand.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Employee, EmployeeResource>();

            CreateMap<Session, SessionResource>();
            CreateMap<User, UserResource>();
            CreateMap<Box, BoxResource>();
            CreateMap<Section, SectionResource>();
            CreateMap<Item, ItemResource>();
            CreateMap<Spec, SpecResource>();
            CreateMap<Shared, SharedResource>();
            CreateMap<SessionResponse, SessionResource>().ReverseMap();
        }
    }
}
