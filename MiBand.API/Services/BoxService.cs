using MiBand.API.Domain.Models;
using MiBand.API.Domain.Repositories.Base;
using MiBand.API.Domain.Repositories;
using MiBand.API.Domain.Services;
using MiBand.API.Domain.Services.Communications;

namespace MiBand.API.Services
{
    public class BoxService : IStateService<Box, BoxResponse>
    {
        private readonly IStateRepository<Box> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public BoxService(IStateRepository<Box> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BoxResponse> DeleteAsync(int id)
        {
            var result = await _repository.FindByStringAsync(id.ToString());
            if (result == null)
                return new BoxResponse("User not found");

            try
            {
                _repository.Delete(result);
                await _unitOfWork.CompleteAsync();

                return new BoxResponse(result);
            }
            catch (Exception e)
            {
                return new BoxResponse($"An error occurred while deleting the user: {e.Message}");
            }
        }

        public async Task<BoxResponse> FindByStringAsync(string value)
        {
            try
            {
                var result = await _repository.FindByStringAsync(value);
                await _unitOfWork.CompleteAsync();

                return new BoxResponse(result);
            }
            catch (Exception e)
            {
                return new BoxResponse($"User not found: {e.Message}");
            }
        }

        public async Task<IEnumerable<Box>> ListByIdAsync(int id)
        {
            return await _repository.ListByIdAsync(id);
        }

        public async Task<BoxResponse> SaveAsync(Box model)
        {
            var existingVal = await _repository.FindByStringAsync(model.Id.ToString());
            if (existingVal != null)
                return new BoxResponse("There is already a user with this Id");

            try
            {
                await _repository.AddAsync(model);
                await _unitOfWork.CompleteAsync();

                return new BoxResponse(model);
            }
            catch (Exception e)
            {
                return new BoxResponse($"An error ocurred while saving the illness: {e.Message}");
            }
        }

        public async Task<BoxResponse> UpdateAsync(int id, Box model)
        {
            var result = await _repository.FindByStringAsync(id.ToString());
            if (result == null)
                return new BoxResponse("User not found");

            result.BoxType = model.BoxType;
            result.PrivateLink = model.PrivateLink;
            result.Download = model.Download;

            result.Favourite = model.Favourite;
            result.Color = model.Color;
            result.Name = model.Name;

            try
            {
                _repository.Update(result);
                await _unitOfWork.CompleteAsync();

                return new BoxResponse(result);
            }
            catch (Exception e)
            {
                return new BoxResponse($"An error occurred while updating the user: {e.Message}");
            }
        }
    }
}
