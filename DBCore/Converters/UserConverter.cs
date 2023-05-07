using System;
using DBModels;
using DTOModels;
using ProjectModels;

namespace DBCore.Converters
{
	public class UserConverter
	{
		public UserConverter() { }

        public UserGroupModel GetUserGroupModelFromUserGroupDto(UserGroupDto userGroupDto)
        {
            if (userGroupDto == null)
                return new UserGroupModel();

            return new UserGroupModel()
            {
                Code = userGroupDto.Code,
                Description = userGroupDto.Description
            };
        }

        public User_Group GetUserGroupFromUserGroupModel(UserGroupModel userGroupModel)
        {
            if (userGroupModel == null)
                return new User_Group();

            return new User_Group()
            {
                Code = userGroupModel.Code,
                Description = userGroupModel.Description
            };
        }

        public UserGroupGetDto GetUserGroupDtoFromUserGroup(User_Group userGroup)
        {
            if (userGroup == null)
                return new UserGroupGetDto();

            return new UserGroupGetDto()
            {
                Id = userGroup.Id,
                Code = userGroup.Code,
                Description = userGroup.Description
            };
        }
        //
        public UserStateModel GetUserStateModelFromUserStateDto(UserStateDto userStateDto)
        {
            if (userStateDto == null)
                return new UserStateModel();

            return new UserStateModel()
            {
                Code = userStateDto.Code,
                Description = userStateDto.Description
            };
        }

        public User_State GetUserStateFromUserStateModel(UserStateModel userStateModel)
        {
            if (userStateModel == null)
                return new User_State();

            return new User_State()
            {
                Code = userStateModel.Code,
                Description = userStateModel.Description
            };
        }

        public UserStateGetDto GetUserStateDtoFromUserState(User_State userState)
        {
            if (userState == null)
                return new UserStateGetDto();

            return new UserStateGetDto()
            {
                Id = userState.Id,
                Code = userState.Code,
                Description = userState.Description
            };
        }
        //
        public UserGetModel GetUserGetModelFromUser(User user, User_Group user_group, User_State user_state)
        {
            if (user == null || user_group == null || user_state == null)
                return new UserGetModel();

            return new UserGetModel()
            {
                Id = user.Id,
                Login = user.Login,
                Password = user.Password,
                Created_Date = user.Created_Date,
                Code_Group = user_group.Code,
                Description_Group = user_group.Description,
                Code_State = user_state.Code,
                Description_State = user_state.Description
            };
        }

        public UserGetDto GetUserGetDtoFromUserGetModel(UserGetModel userGetModel)
        {
            if (userGetModel == null)
                return new UserGetDto();

            return new UserGetDto()
            {
                Id = userGetModel.Id,
                Login = userGetModel.Login,
                Password = userGetModel.Password,
                Created_Date = userGetModel.Created_Date,
                Code_Group = userGetModel.Code_Group,
                Description_Group = userGetModel.Description_Group,
                Code_State = userGetModel.Code_State,
                Description_State = userGetModel.Description_State
            };
        }

        public UserModel GetUserModelFromUserDto(UserDto userDto)
        {
            if (userDto == null)
                return new UserModel();

            return new UserModel()
            {
                Login = userDto.Login,
                Password = userDto.Password,
                User_Group_Id = userDto.User_Group_Id
            };
        }

        public User GetUserFromUserModel(UserModel userModel)
        {
            if (userModel == null)
                return new User();

            return new User()
            {
                Login = userModel.Login,
                Password = userModel.Password,
                User_Group_Id = userModel.User_Group_Id
            };
        }
    }
}

