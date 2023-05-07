using System;
using DBCore;
using DBCore.Converters;
using DBModels;
using DTOModels;
using ProjectModels;

namespace Project
{
	public class UserHandler
	{
		public UserHandler() { }

        public async Task AddUserInDB(UserDto userDto, IUserRepository postgresSQLUserRepository)
        {
            var userModel = new UserConverter().GetUserModelFromUserDto(userDto);

            try
            {
                if (userModel == null ||
                    String.IsNullOrWhiteSpace(userModel.Login) ||
                    String.IsNullOrWhiteSpace(userModel.Password) ||
                    userModel.User_Group_Id < 0)
                    throw new ArgumentNullException();

                var user = new UserConverter().GetUserFromUserModel(userModel);

                await postgresSQLUserRepository.AddUser(user);
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

        public async Task DeleteUserByModel(UserDto userDto, IUserRepository postgresSQLUserRepository)
        {
            var userModel = new UserConverter().GetUserModelFromUserDto(userDto);

            try
            {
                if (userModel == null ||
                    String.IsNullOrWhiteSpace(userModel.Login) ||
                    String.IsNullOrWhiteSpace(userModel.Password) ||
                    userModel.User_Group_Id < 0)
                    throw new ArgumentNullException();

                var user = new UserConverter().GetUserFromUserModel(userModel);

                await postgresSQLUserRepository.DeleteUserByModel(user);
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

        public async Task DeleteUserById(long userId, IUserRepository postgresSQLUserRepository)
        {
            try
            {
                if (userId < 0)
                    throw new ArgumentNullException();

                await postgresSQLUserRepository.DeleteUserById(userId);
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

        public async Task<List<UserGetDto>> GetAllUser(IUserRepository postgresSQLUserRepository)
        {
            try
            {
                var allUserGetModel = await postgresSQLUserRepository.GetAllUser();

                return allUserGetModel.Select(x => new UserConverter().GetUserGetDtoFromUserGetModel(x)).ToList();
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

        public async Task<List<UserGetDto>> GetMultipleUser(int count, IUserRepository postgresSQLUserRepository)
        {
            try
            {
                var allUserGetModel = await postgresSQLUserRepository.GetMultipleUser(count);

                return allUserGetModel.Select(x => new UserConverter().GetUserGetDtoFromUserGetModel(x)).ToList();
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

