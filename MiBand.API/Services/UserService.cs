using MiBand.API.Domain.Models;
using MiBand.API.Domain.Repositories;
using MiBand.API.Domain.Repositories.Base;
using MiBand.API.Domain.Services;
using MiBand.API.Domain.Services.Communications;
using MiBand.API.Persistence.Repositories;

namespace MiBand.API.Services
{
    public class UserService : IBaseService<User,UserResponse>
    {
        private readonly IBaseRespository<User> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IBaseRespository<User> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserResponse> DeleteAsync(int id)
        {
            var result = await _repository.FindByIdAsync(id);
            if (result == null)
                return new UserResponse("User not found");

            try
            {
                _repository.Delete(result);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(result);
            }
            catch (Exception e)
            {
                return new UserResponse($"An error occurred while deleting the user: {e.Message}");
            }
        }

        public async Task<UserResponse> FindByIdAsync(int id)
        {
            try
            {
                var result = await _repository.FindByIdAsync(id);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(result);
            }
            catch (Exception e)
            {
                return new UserResponse($"User not found: {e.Message}");
            }
        }

        public async Task<UserResponse> SaveAsync(User model)
        {
            var existingVal = await _repository.FindByIdAsync(model.Id);
            if (existingVal != null)
                return new UserResponse("There is already a user with this Id");

            try
            {
                model.CreatedDate = DateTime.Now.ToString();
                await _repository.AddAsync(model);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(model);
            }
            catch (Exception e)
            {
                return new UserResponse($"An error ocurred while saving the illness: {e.Message}");
            }
        }

        public async Task<UserResponse> UpdateAsync(int id, User model)
        {
            var result = await _repository.FindByIdAsync(id);
            if (result == null)
                return new UserResponse("User not found");

            result.Name = model.Name;
            result.Lastname = model.Lastname;
            result.UserPhoto = model.UserPhoto;
            result.Birthday = model.Birthday;
            result.Boxes = model.Boxes;
            result.BoxCounter = model.BoxCounter;

            result.Active = model.Active;
            result.UpdatedDate = DateTime.Now.ToString();

            try
            {
                _repository.Update(result);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(result);
            }
            catch (Exception e)
            {
                return new UserResponse($"An error occurred while updating the user: {e.Message}");
            }
        }
    }
}
