﻿using MiBand.API.Domain.Models;

namespace MiBand.API.Domain.Repositories
{
    public interface IEmployeeRepository
    {
        Task AddAsync(Employee employee);
        Task<Employee> FindByIdAsync(int employeeId);
        void Update(Employee employee);
        void Remove(Employee employee);
    }
}
