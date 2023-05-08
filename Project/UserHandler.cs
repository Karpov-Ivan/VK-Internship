﻿using System;
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

        public async Task AddUserInDBAsync(UserDto userDto, IUserRepository postgresSQLUserRepository)
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

                await postgresSQLUserRepository.AddUserAsync(user);
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

        public async Task DeleteUserByModelAsync(UserDto userDto, IUserRepository postgresSQLUserRepository)
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

                await postgresSQLUserRepository.DeleteUserByModelAsync(user);
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

        public async Task DeleteUserByIdAsync(long userId, IUserRepository postgresSQLUserRepository)
        {
            try
            {
                if (userId < 0)
                    throw new ArgumentNullException();

                await postgresSQLUserRepository.DeleteUserByIdAsync(userId);
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

        public async Task<List<UserGetDto>> GetAllUserAsync(IUserRepository postgresSQLUserRepository)
        {
            try
            {
                var allUserGetModel = await postgresSQLUserRepository.GetAllUserAsync();

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

        public async Task<List<UserGetDto>> GetMultipleUserAsync(int count, IUserRepository postgresSQLUserRepository)
        {
            try
            {
                var allUserGetModel = await postgresSQLUserRepository.GetMultipleUserAsync(count);

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

