using MiBand.API.Domain.Models;
using MiBand.API.Domain.Repositories.Base;
using MiBand.API.Domain.Repositories;
using MiBand.API.Domain.Services;
using MiBand.API.Domain.Services.Communications;

namespace MiBand.API.Services
{
    public class SectionService : IStateService<Section, SectionResponse>
    {
        private readonly IStateRepository<Section> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public SectionService(IStateRepository<Section> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<SectionResponse> DeleteAsync(int id)
        {
            var result = await _repository.FindByIdAsync(id);
            if (result == null)
                return new SectionResponse("User not found");

            try
            {
                _repository.Delete(result);
                await _unitOfWork.CompleteAsync();

                return new SectionResponse(result);
            }
            catch (Exception e)
            {
                return new SectionResponse($"An error occurred while deleting the user: {e.Message}");
            }
        }

        public async Task<SectionResponse> FindByIdAsync(int id)
        {
            try
            {
                var result = await _repository.FindByIdAsync(id);
                await _unitOfWork.CompleteAsync();

                return new SectionResponse(result);
            }
            catch (Exception e)
            {
                return new SectionResponse($"User not found: {e.Message}");
            }
        }

        public async Task<IEnumerable<Section>> ListByIdAsync(int id)
        {
            return await _repository.ListByIdAsync(id);
        }

        public async Task<SectionResponse> SaveAsync(Section model)
        {
            var existingVal = await _repository.FindByIdAsync(model.Id);
            if (existingVal != null)
                return new SectionResponse("There is already a user with this Id");

            try
            {
                model.CreatedDate = DateTime.Now.ToString();
                await _repository.AddAsync(model);
                await _unitOfWork.CompleteAsync();

                return new SectionResponse(model);
            }
            catch (Exception e)
            {
                return new SectionResponse($"An error ocurred while saving the illness: {e.Message}");
            }
        }

        public async Task<SectionResponse> UpdateAsync(int id, Section model)
        {
            var result = await _repository.FindByIdAsync(id);
            if (result == null)
                return new SectionResponse("User not found");

            result.Favourite = model.Favourite;
            result.Color = model.Color;
            result.Name = model.Name;

            result.Active = model.Active;
            result.UpdatedDate = DateTime.Now.ToString();
            try
            {
                _repository.Update(result);
                await _unitOfWork.CompleteAsync();

                return new SectionResponse(result);
            }
            catch (Exception e)
            {
                return new SectionResponse($"An error occurred while updating the user: {e.Message}");
            }
        }
    }
}
