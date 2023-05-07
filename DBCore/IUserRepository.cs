using System;
using DBModels;
using ProjectEnum;
using ProjectModels;

namespace DBCore
{
	public interface IUserRepository
	{
        public Task AddUser(User user);

        public Task DeleteUserByModel(User user);

        public Task DeleteUserById(long userId);

        public Task<List<UserGetModel>> GetAllUser();

        public Task<List<UserGetModel>> GetMultipleUser(int count);
    }
}

