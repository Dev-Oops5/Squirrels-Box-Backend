using MiBand.API.Domain.Models;
using MiBand.API.Domain.Repositories.Base;
using MiBand.API.Domain.Repositories;
using MiBand.API.Domain.Services;
using MiBand.API.Domain.Services.Communications;

namespace MiBand.API.Services
{
    public class SpecService : IStateService<Spec, SpecResponse>
    {
        private readonly IStateRepository<Spec> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public SpecService(IStateRepository<Spec> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<SpecResponse> DeleteAsync(int id)
        {
            var result = await _repository.FindByIdAsync(id);
            if (result == null)
                return new SpecResponse("User not found");

            try
            {
                _repository.Delete(result);
                await _unitOfWork.CompleteAsync();

                return new SpecResponse(result);
            }
            catch (Exception e)
            {
                return new SpecResponse($"An error occurred while deleting the user: {e.Message}");
            }
        }

        public async Task<SpecResponse> FindByIdAsync(int id)
        {
            try
            {
                var result = await _repository.FindByIdAsync(id);
                await _unitOfWork.CompleteAsync();

                return new SpecResponse(result);
            }
            catch (Exception e)
            {
                return new SpecResponse($"User not found: {e.Message}");
            }
        }

        public async Task<IEnumerable<Spec>> ListByIdAsync(int id)
        {
            return await _repository.ListByIdAsync(id);
        }

        public async Task<SpecResponse> SaveAsync(Spec model)
        {
            var existingVal = await _repository.FindByIdAsync(model.Id);
            if (existingVal != null)
                return new SpecResponse("There is already a user with this Id");

            try
            {
                model.CreatedDate = DateTime.Now.ToString();
                await _repository.AddAsync(model);
                await _unitOfWork.CompleteAsync();

                return new SpecResponse(model);
            }
            catch (Exception e)
            {
                return new SpecResponse($"An error ocurred while saving the illness: {e.Message}");
            }
        }

        public async Task<SpecResponse> UpdateAsync(int id, Spec model)
        {
            var result = await _repository.FindByIdAsync(id);
            if (result == null)
                return new SpecResponse("User not found");

            result.VariableType = model.VariableType;
            result.Content = model.Content;
            result.Currency = model.Currency;

            result.Favourite = model.Favourite;
            result.Color = model.Color;
            result.Name = model.Name;

            result.Active = model.Active;
            result.UpdatedDate = DateTime.Now.ToString();
            try
            {
                _repository.Update(result);
                await _unitOfWork.CompleteAsync();

                return new SpecResponse(result);
            }
            catch (Exception e)
            {
                return new SpecResponse($"An error occurred while updating the user: {e.Message}");
            }
        }
    }
}
