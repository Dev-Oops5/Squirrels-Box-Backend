using MiBand.API.Domain.Models;
using MiBand.API.Domain.Repositories;
using MiBand.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace MiBand.API.Persistence.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext db;

        public EmployeeRepository(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Employee>> ListAsync() => await db.Employees.ToListAsync();

        public async Task AddAsync(Employee employee)
        {
            await db.Employees.AddAsync(employee);
            db.SaveChanges();
        }

        public void Remove(Employee employee)
        {
            db.Employees.Remove(employee);
        }

        public void Update(Employee employee)
        {
            db.Employees.Update(employee);
        }

        public Task<Employee> FindByIdAsync(int employeeId)
        {
            return db.Employees.Where(x => x.EmployeeId == employeeId).FirstOrDefaultAsync();
        }
    }
}
