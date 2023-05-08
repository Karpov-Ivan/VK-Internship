using System;
using DBModels;
using Microsoft.EntityFrameworkCore;
using ProjectEnum;

namespace DBCore
{
	public interface IUserGroupRepository
	{
        public Task AddUserGroupAsync(User_Group userGroup);

        public Task DeleteUserGroupByModelAsync(User_Group userGroup);

        public Task DeleteUserGroupByCodeAsync(EnumGroup enumGroup);

        public Task DeleteUserGroupByIdAsync(long userGroupId);

        public Task ChangeUserGroupAsync(User_Group userGroup);

        public Task<List<User_Group>> GetAllUserGroupAsync();
    }
}

