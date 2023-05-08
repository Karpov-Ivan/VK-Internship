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

		public async Task AddUserGroupInDBAsync(UserGroupDto userGroupDto,
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

                await postgresSQLUserGroupRepository.AddUserGroupAsync(userGroup);
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

        public async Task DeleteUserGroupByModelAsync(UserGroupDto userGroupDto,
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

                await postgresSQLUserGroupRepository.DeleteUserGroupByModelAsync(userGroup);
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

        public async Task DeleteUserGroupByCodeAsync(EnumGroup enumGroup,
                                                     IUserGroupRepository postgresSQLUserGroupRepository)
        {
            try
            {
                if (enumGroup != ProjectEnum.EnumGroup.Admin &&
                    enumGroup != ProjectEnum.EnumGroup.User)
                    throw new ArgumentNullException();

                await postgresSQLUserGroupRepository.DeleteUserGroupByCodeAsync(enumGroup);
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

        public async Task DeleteUserGroupByIdAsync(long userGroupId,
                                                   IUserGroupRepository postgresSQLUserGroupRepository)
        {
            try
            {
                if (userGroupId < 0)
                    throw new ArgumentNullException();

                await postgresSQLUserGroupRepository.DeleteUserGroupByIdAsync(userGroupId);
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

        public async Task ChangeUserGroupAsync(UserGroupDto userGroupDto,
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

                await postgresSQLUserGroupRepository.ChangeUserGroupAsync(userGroup);
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

        public async Task<List<UserGroupGetDto>> GetAllUserGroupAsync(IUserGroupRepository postgresSQLUserGroupRepository)
        {
            try
            {
                var allUserGroupModel = await postgresSQLUserGroupRepository.GetAllUserGroupAsync();

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

