using MiBand.API.Domain.Models;
using MiBand.API.Domain.Services.Communications;

namespace MiBand.API.Domain.Services
{
    public interface IEmployeeService
    {
        //Task<IEnumerable<Employee>> GetAllAsync();
        Task<EmployeeResponse> GetByIdAsync(int employeeId);
        Task<EmployeeResponse> SaveAsync(Employee employee);
        Task<EmployeeResponse> UpdateAsync(int employeeId, Employee employeeRequest);
        Task<EmployeeResponse> DeleteAsync(int employeeId);

    }
}
