using System;
using DBModels;
using ProjectEnum;

namespace DBCore
{
	public interface IUserStateRepository
	{
        public Task AddUserState(User_State userState);

        public Task DeleteUserStateByModel(User_State userState);

        public Task DeleteUserStateByCode(EnumState enumState);

        public Task DeleteUserStateById(long userStateId);

        public Task ChangeUserState(User_State userState);

        public Task<List<User_State>> GetAllUserState();
    }
}

