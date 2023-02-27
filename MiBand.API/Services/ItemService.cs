using MiBand.API.Domain.Models;
using MiBand.API.Domain.Repositories.Base;
using MiBand.API.Domain.Repositories;
using MiBand.API.Domain.Services;
using MiBand.API.Domain.Services.Communications;

namespace MiBand.API.Services
{
    public class ItemService : IStateService<Item, ItemResponse>
    {
        private readonly IStateRepository<Item> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ItemService(IStateRepository<Item> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ItemResponse> DeleteAsync(int id)
        {
            var result = await _repository.FindByIdAsync(id);
            if (result == null)
                return new ItemResponse("User not found");

            try
            {
                _repository.Delete(result);
                await _unitOfWork.CompleteAsync();

                return new ItemResponse(result);
            }
            catch (Exception e)
            {
                return new ItemResponse($"An error occurred while deleting the user: {e.Message}");
            }
        }

        public async Task<ItemResponse> FindByIdAsync(int id)
        {
            try
            {
                var result = await _repository.FindByIdAsync(id);
                await _unitOfWork.CompleteAsync();

                return new ItemResponse(result);
            }
            catch (Exception e)
            {
                return new ItemResponse($"User not found: {e.Message}");
            }
        }

        public async Task<IEnumerable<Item>> ListByIdAsync(int id)
        {
            return await _repository.ListByIdAsync(id);
        }

        public async Task<ItemResponse> SaveAsync(Item model)
        {
            var existingVal = await _repository.FindByIdAsync(model.Id);
            if (existingVal != null)
                return new ItemResponse("There is already a user with this Id");

            try
            {
                model.CreatedDate = DateTime.Now.ToString();
                await _repository.AddAsync(model);
                await _unitOfWork.CompleteAsync();

                return new ItemResponse(model);
            }
            catch (Exception e)
            {
                return new ItemResponse($"An error ocurred while saving the illness: {e.Message}");
            }
        }

        public async Task<ItemResponse> UpdateAsync(int id, Item model)
        {
            var result = await _repository.FindByIdAsync(id);
            if (result == null)
                return new ItemResponse("User not found");

            result.Description = model.Description;
            result.Amount = model.Amount;
            result.ItemPhoto = model.ItemPhoto;

            result.Favourite = model.Favourite;
            result.Color = model.Color;
            result.Name = model.Name;

            result.Active = model.Active;
            result.UpdatedDate = DateTime.Now.ToString();
            try
            {
                _repository.Update(result);
                await _unitOfWork.CompleteAsync();

                return new ItemResponse(result);
            }
            catch (Exception e)
            {
                return new ItemResponse($"An error occurred while updating the user: {e.Message}");
            }
        }
    }
}
