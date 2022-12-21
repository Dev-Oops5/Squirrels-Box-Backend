using AutoMapper;
using MiBand.API.Domain.Models;
using MiBand.API.Resources;

namespace MiBand.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Employee, EmployeeResource>();
        }
    }
}
