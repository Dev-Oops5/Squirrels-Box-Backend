using MiBand.API.Domain.Models;
using MiBand.API.Domain.Repositories.Base;
using MiBand.API.Domain.Repositories;
using MiBand.API.Domain.Services;
using MiBand.API.Domain.Services.Communications;
using MiBand.API.Persistence.Repositories;

namespace MiBand.API.Services
{
    public class SessionService : IBaseService<Session, SessionResponse>
    {
        private readonly IBaseRespository<Session> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public SessionService(IBaseRespository<Session> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<SessionResponse> DeleteAsync(int id)
        {
            var result = await _repository.FindByStringAsync(id.ToString());
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

        public async Task<SessionResponse> FindByStringAsync(string value)
        {
            try
            {
                var result = await _repository.FindByStringAsync(value);
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
            var existingVal = await _repository.FindByStringAsync(model.Id.ToString());
            if (existingVal != null)
                return new SessionResponse("There is already a User Session with this Id");

            try
            {
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
            var result = await _repository.FindByStringAsync(id.ToString());
            if (result == null)
                return new SessionResponse("User Session not found");

            result.Username = model.Username;
            result.Email = model.Email;
            result.Password = model.Password;

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
