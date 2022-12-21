using MiBand.API.Domain.Models;

namespace MiBand.API.Domain.Services.Communications
{
    public class EmployeeResponse : BaseResponse<Employee>
    {
        public EmployeeResponse(Employee resource) : base(resource)
        {
        }

        public EmployeeResponse(string message) : base(message)
        {
        }
    }
}
