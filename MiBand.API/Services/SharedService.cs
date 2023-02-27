using MiBand.API.Domain.Models;
using MiBand.API.Domain.Services.Communications;
using MiBand.API.Domain.Services;
using MiBand.API.Domain.Repositories.Base;
using MiBand.API.Domain.Repositories;

namespace MiBand.API.Services
{
    public class SharedService : IStateService<Shared, SharedResponse>
    {
        private readonly IStateRepository<Shared> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public SharedService(IStateRepository<Shared> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<SharedResponse> DeleteAsync(int id)
        {
            var result = await _repository.FindByIdAsync(id);
            if (result == null)
                return new SharedResponse("User not found");

            try
            {
                _repository.Delete(result);
                await _unitOfWork.CompleteAsync();

                return new SharedResponse(result);
            }
            catch (Exception e)
            {
                return new SharedResponse($"An error occurred while deleting the user: {e.Message}");
            }
        }

        public async Task<SharedResponse> FindByIdAsync(int id)
        {
            try
            {
                var result = await _repository.FindByIdAsync(id);
                await _unitOfWork.CompleteAsync();

                return new SharedResponse(result);
            }
            catch (Exception e)
            {
                return new SharedResponse($"User not found: {e.Message}");
            }
        }

        public async Task<IEnumerable<Shared>> ListByIdAsync(int id)
        {
            return await _repository.ListByIdAsync(id);
        }

        public async Task<SharedResponse> SaveAsync(Shared model)
        {
            var existingVal = await _repository.FindByIdAsync(model.Id);
            if (existingVal != null)
                return new SharedResponse("There is already a user with this Id");

            try
            {
                model.CreatedDate = DateTime.Now.ToString();
                await _repository.AddAsync(model);
                await _unitOfWork.CompleteAsync();

                return new SharedResponse(model);
            }
            catch (Exception e)
            {
                return new SharedResponse($"An error ocurred while saving the illness: {e.Message}");
            }
        }

        public async Task<SharedResponse> UpdateAsync(int id, Shared model)
        {
            var result = await _repository.FindByIdAsync(id);
            if (result == null)
                return new SharedResponse("User not found");

            result.OwnerId = model.OwnerId;
            result.ReceiverId = model.ReceiverId;
            result.BoxId = model.BoxId;

            result.Active = model.Active;
            result.UpdatedDate = DateTime.Now.ToString();

            try
            {
                _repository.Update(result);
                await _unitOfWork.CompleteAsync();

                return new SharedResponse(result);
            }
            catch (Exception e)
            {
                return new SharedResponse($"An error occurred while updating the user: {e.Message}");
            }
        }
    }
}
