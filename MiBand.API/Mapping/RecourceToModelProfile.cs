using AutoMapper;
using MiBand.API.Domain.Models;
using MiBand.API.Resources;

namespace MiBand.API.Mapping
{
    public class RecourceToModelProfile : Profile
    {
        public RecourceToModelProfile()
        {
            CreateMap<SaveEmployeeResource, Employee>();
        }
    }
}
