using System;
using DBModels;
using ProjectEnum;
using ProjectModels;

namespace DBCore
{
	public interface IUserRepository
	{
        public Task AddUserAsync(User user);

        public Task DeleteUserByModelAsync(User user);

        public Task DeleteUserByIdAsync(long userId);

        public Task<List<UserGetModel>> GetAllUserAsync();

        public Task<List<UserGetModel>> GetMultipleUserAsync(int count);
    }
}

