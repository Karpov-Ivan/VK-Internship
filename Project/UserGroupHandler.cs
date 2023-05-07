using System;
using Azure;
using DBCore;
using DBCore.Converters;
using DBModels;
using DTOModels;
using Microsoft.EntityFrameworkCore;
using ProjectEnum;
using ProjectModels;

namespace Project
{
	public class UserGroupHandler
    {
		public UserGroupHandler() { }

		public async Task AddUserGroupInDB(UserGroupDto userGroupDto,
                                     IUserGroupRepository postgresSQLUserGroupRepository)
		{
            var userGroupModel = new UserConverter().GetUserGroupModelFromUserGroupDto(userGroupDto);

            try
			{
				if (userGroupModel == null ||
                    String.IsNullOrWhiteSpace(userGroupModel.Description) ||
					(userGroupModel.Code != ProjectEnum.EnumGroup.Admin &&
					userGroupModel.Code != ProjectEnum.EnumGroup.User))
					throw new ArgumentNullException();

				var userGroup = new UserConverter().GetUserGroupFromUserGroupModel(userGroupModel);

                await postgresSQLUserGroupRepository.AddUserGroup(userGroup);
			}
            catch (DuplicateWaitObjectException exception)
            {
                throw new DuplicateWaitObjectException(exception.Message);
            }
            catch (ArgumentNullException exception)
			{
				throw new ArgumentNullException(exception.Message);
			}
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public async Task DeleteUserGroupByModel(UserGroupDto userGroupDto,
                                                 IUserGroupRepository postgresSQLUserGroupRepository)
        {
            var userGroupModel = new UserConverter().GetUserGroupModelFromUserGroupDto(userGroupDto);

            try
            {
                if (userGroupModel == null ||
                    String.IsNullOrWhiteSpace(userGroupModel.Description) ||
                    (userGroupModel.Code != ProjectEnum.EnumGroup.Admin &&
                    userGroupModel.Code != ProjectEnum.EnumGroup.User))
                    throw new ArgumentNullException();

                var userGroup = new UserConverter().GetUserGroupFromUserGroupModel(userGroupModel);

                await postgresSQLUserGroupRepository.DeleteUserGroupByModel(userGroup);
            }
            catch (ArgumentNullException exception)
            {
                throw new ArgumentNullException(exception.Message);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public async Task DeleteUserGroupByCode(EnumGroup enumGroup,
                                                IUserGroupRepository postgresSQLUserGroupRepository)
        {
            try
            {
                if (enumGroup != ProjectEnum.EnumGroup.Admin &&
                    enumGroup != ProjectEnum.EnumGroup.User)
                    throw new ArgumentNullException();

                await postgresSQLUserGroupRepository.DeleteUserGroupByCode(enumGroup);
            }
            catch (ArgumentNullException exception)
            {
                throw new ArgumentNullException(exception.Message);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public async Task DeleteUserGroupById(long userGroupId,
                                              IUserGroupRepository postgresSQLUserGroupRepository)
        {
            try
            {
                if (userGroupId < 0)
                    throw new ArgumentNullException();

                await postgresSQLUserGroupRepository.DeleteUserGroupById(userGroupId);
            }
            catch (ArgumentNullException exception)
            {
                throw new ArgumentNullException(exception.Message);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public async Task ChangeUserGroup(UserGroupDto userGroupDto,
                                          IUserGroupRepository postgresSQLUserGroupRepository)
        {
            var userGroupModel = new UserConverter().GetUserGroupModelFromUserGroupDto(userGroupDto);

            try
            {
                if (userGroupModel == null ||
                    String.IsNullOrWhiteSpace(userGroupModel.Description) ||
                    (userGroupModel.Code != ProjectEnum.EnumGroup.Admin &&
                    userGroupModel.Code != ProjectEnum.EnumGroup.User))
                    throw new ArgumentNullException();

                var userGroup = new UserConverter().GetUserGroupFromUserGroupModel(userGroupModel);

                await postgresSQLUserGroupRepository.ChangeUserGroup(userGroup);
            }
            catch (ArgumentNullException exception)
            {
                throw new ArgumentNullException(exception.Message);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public async Task<List<UserGroupGetDto>> GetAllUserGroup(IUserGroupRepository postgresSQLUserGroupRepository)
        {
            try
            {
                var allUserGroupModel = await postgresSQLUserGroupRepository.GetAllUserGroup();

                return allUserGroupModel.Select(x => new UserConverter().GetUserGroupDtoFromUserGroup(x)).ToList();
            }
            catch (ArgumentNullException exception)
            {
                throw new ArgumentNullException(exception.Message);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}

