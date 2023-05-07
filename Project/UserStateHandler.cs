using System;
using DBCore;
using DBCore.Converters;
using DTOModels;
using ProjectModels;

namespace Project
{
	public class UserStateHandler
	{
		public UserStateHandler() { }

		public void AddUserGroupInDB(UserGroupDto userGroupDto,
                                     IUserGroupRepository postgresSQLUserGroupRepository)
		{
            var userGroupModel = new UserConverter().GetUserGroupModelFromUserGroupDto(userGroupDto);

            try
			{
				if (userGroupModel == null ||
                    userGroupModel.Description == null ||
					userGroupModel.Description == "" ||
					userGroupModel.Code != ProjectEnum.EnumGroup.Admin ||
					userGroupModel.Code != ProjectEnum.EnumGroup.User)
					throw new ArgumentNullException();

				var userGroup = new UserConverter().GetUserGroupFromUserGroupModel(userGroupModel);

                postgresSQLUserGroupRepository.AddUserGroup(userGroup);
			}
			catch (ArgumentNullException exception)
			{
				throw new ArgumentNullException(exception.Message);
			}
		}
	}
}

