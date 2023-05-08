using System;
using DBModels;
using ProjectEnum;

namespace DBCore
{
	public interface IUserStateRepository
	{
        public Task AddUserStateAsync(User_State userState);

        public Task DeleteUserStateByModelAsync(User_State userState);

        public Task DeleteUserStateByCodeAsync(EnumState enumState);

        public Task DeleteUserStateByIdAsync(long userStateId);

        public Task ChangeUserStateAsync(User_State userState);

        public Task<List<User_State>> GetAllUserStateAsync();
    }
}

