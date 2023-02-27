using MiBand.API.Domain.Models;

namespace MiBand.API.Domain.Repositories.Base
{
    public interface IBaseRespository<T>
    {
        Task AddAsync(T model);
        Task<T> FindByIdAsync(int id);
        void Update(T model);
        void Delete(T model);
    }
}
