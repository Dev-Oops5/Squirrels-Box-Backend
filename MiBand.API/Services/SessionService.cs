using MiBand.API.Domain.Models;
using MiBand.API.Domain.Repositories.Base;
using MiBand.API.Domain.Repositories;
using MiBand.API.Domain.Services;
using MiBand.API.Domain.Services.Communications;
using MiBand.API.Persistence.Repositories;

namespace MiBand.API.Services
{
    public class SessionService : IBaseService<Session, SessionResponse>, ISessionService
    {
        private readonly IBaseRespository<Session> _repository;
        private readonly ISessionRepository _sessionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SessionService(IBaseRespository<Session> repository, ISessionRepository sessionRepository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _sessionRepository = sessionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<SessionResponse> DeleteAsync(int id)
        {
            var result = await _repository.FindByIdAsync(id);
            if (result == null)
                return new SessionResponse("User Session not found");

            try
            {
                _repository.Delete(result);
                await _unitOfWork.CompleteAsync();

                return new SessionResponse(result);
            }
            catch (Exception e)
            {
                return new SessionResponse($"An error occurred while deleting the user session: {e.Message}");
            }
        }

        public async Task<SessionResponse> FindByIdAsync(int id)
        {
            try
            {
                var result = await _repository.FindByIdAsync(id);
                await _unitOfWork.CompleteAsync();

                return new SessionResponse(result);
            }
            catch (Exception e)
            {
                return new SessionResponse($"User Session not found: {e.Message}");
            }
        }

        public async Task<SessionResponse> FindByUsernameOrEmailAndPasswordAsync(string username, string email, string password)
        {
            try
            {
                var result = await _sessionRepository.FindByUsernameOrEmailAndPasswordAsync(username, email, password);
                await _unitOfWork.CompleteAsync();

                return new SessionResponse(result);
            }
            catch (Exception e)
            {
                return new SessionResponse($"User Session not found: {e.Message}");
            }
        }

        public async Task<SessionResponse> SaveAsync(Session model)
        {
            var existingVal = await _repository.FindByIdAsync(model.Id);
            if (existingVal != null)
                return new SessionResponse("There is already a User Session with this Id");

            try
            {
                model.CreatedDate = DateTime.Now.ToString();
                await _repository.AddAsync(model);
                await _unitOfWork.CompleteAsync();

                return new SessionResponse(model);
            }
            catch (Exception e)
            {
                return new SessionResponse($"An error ocurred while saving the User Session: {e.Message}");
            }
        }

        public async Task<SessionResponse> UpdateAsync(int id, Session model)
        {
            var result = await _repository.FindByIdAsync(id);
            if (result == null)
                return new SessionResponse("User Session not found");

            result.Username = model.Username;
            result.Email = model.Email;
            result.Password = model.Password;

            result.Active = model.Active;
            result.UpdatedDate = DateTime.Now.ToString();

            try
            {
                _repository.Update(result);
                await _unitOfWork.CompleteAsync();

                return new SessionResponse(result);
            }
            catch (Exception e)
            {
                return new SessionResponse($"An error occurred while updating the user session: {e.Message}");
            }
        }
    }
}
