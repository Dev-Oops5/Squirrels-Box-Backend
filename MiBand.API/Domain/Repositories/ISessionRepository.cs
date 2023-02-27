using MiBand.API.Domain.Models;

namespace MiBand.API.Domain.Repositories
{
    public interface ISessionRepository
    {
        Task<Session> FindByUsernameOrEmailAndPasswordAsync(string username, string email, string password);
    }
}
