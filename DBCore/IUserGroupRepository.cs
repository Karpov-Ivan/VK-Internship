using System;
using DBModels;
using Microsoft.EntityFrameworkCore;
using ProjectEnum;

namespace DBCore
{
	public interface IUserGroupRepository
	{
        public Task AddUserGroup(User_Group userGroup);

        public Task DeleteUserGroupByModel(User_Group userGroup);

        public Task DeleteUserGroupByCode(EnumGroup enumGroup);

        public Task DeleteUserGroupById(long userGroupId);

        public Task ChangeUserGroup(User_Group userGroup);

        public Task<List<User_Group>> GetAllUserGroup();
    }
}

