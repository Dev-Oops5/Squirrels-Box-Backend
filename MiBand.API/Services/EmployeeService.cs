using MiBand.API.Domain.Models;
using MiBand.API.Domain.Repositories;
using MiBand.API.Domain.Services;
using MiBand.API.Domain.Services.Communications;
using MiBand.API.Persistence.Repositories;

namespace MiBand.API.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IEmployeeRepository surveyRepository, IUnitOfWork unitOfWork)
        {
            _employeeRepository = surveyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<EmployeeResponse> DeleteAsync(int employeeId)
        {
            var existingEmployee = await _employeeRepository.FindByIdAsync(employeeId);

            if (existingEmployee == null)
                return new EmployeeResponse("Employee not found");

            try
            {
                _employeeRepository.Remove(existingEmployee);
                await _unitOfWork.CompleteAsync();

                return new EmployeeResponse(existingEmployee);
            }
            catch (Exception ex)
            {
                return new EmployeeResponse($"An error ocurred while deleting the employee: {ex.Message}");
            }
        }

        //public async Task<IEnumerable<Employee>> GetAllAsync()
        //{
        //    return await _employeeRepository.ListAsync();
        //}

        public async Task<EmployeeResponse> GetByIdAsync(int employeeId)
        {
            var existingEmployee= await _employeeRepository.FindByIdAsync(employeeId);

            if (existingEmployee == null)
                return new EmployeeResponse("Employee not found");

            return new EmployeeResponse(existingEmployee);
        }

        public async Task<EmployeeResponse> SaveAsync(Employee employee)
        {
            try
            {
                await _employeeRepository.AddAsync(employee);
                //await _unitOfWork.CompleteAsync();

                return new EmployeeResponse(employee);
            }
            catch (Exception ex)
            {
                return new EmployeeResponse($"An error ocurred while saving the employee: {ex.Message}");
            }
        }

        public async Task<EmployeeResponse> UpdateAsync(int employeeId, Employee employeeRequest)
        {
            var existingEmployee = await _employeeRepository.FindByIdAsync(employeeId);

            if (existingEmployee == null)
                return new EmployeeResponse("Employee not found");

            existingEmployee.Name = employeeRequest.Name;
            existingEmployee.Citizenship = employeeRequest.Citizenship;

            try
            {
                _employeeRepository.Update(existingEmployee);
                await _unitOfWork.CompleteAsync();

                return new EmployeeResponse(existingEmployee);
            }
            catch (Exception ex)
            {
                return new EmployeeResponse($"An error ocurred while updating the employee: {ex.Message}");
            }
        }
    }
}
