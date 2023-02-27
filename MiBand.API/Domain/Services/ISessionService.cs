using MiBand.API.Domain.Services.Communications;

namespace MiBand.API.Domain.Services
{
    public interface ISessionService
    {
        Task<SessionResponse> FindByUsernameOrEmailAndPasswordAsync(string username, string email, string password);
    }
}
