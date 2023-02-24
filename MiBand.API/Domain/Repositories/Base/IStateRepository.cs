using MiBand.API.Domain.Models;

namespace MiBand.API.Domain.Repositories.Base
{
    public interface IStateRepository<T> : IBaseRespository<T>
    {
        Task<IEnumerable<T>> ListByIdAsync(int id);
    }
}
