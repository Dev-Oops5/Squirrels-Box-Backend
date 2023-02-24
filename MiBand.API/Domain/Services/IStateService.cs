namespace MiBand.API.Domain.Services
{
    public interface IStateService<T,R> : IBaseService<T,R>
    {
        Task<IEnumerable<T>> ListByIdAsync(int id);
    }
}
