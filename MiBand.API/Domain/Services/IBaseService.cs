using MiBand.API.Domain.Models;

namespace MiBand.API.Domain.Services
{
    public interface IBaseService<T,R>
    {
        Task<R> SaveAsync(T model);
        Task<R> FindByIdAsync(int id);
        Task<R> UpdateAsync(int id, T model);
        Task<R> DeleteAsync(int id);
    }
}
