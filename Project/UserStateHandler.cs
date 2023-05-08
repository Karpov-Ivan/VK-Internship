using System;
using DBCore;
using DBCore.Converters;
using DTOModels;
using ProjectEnum;

namespace Project
{
	public class UserStateHandler
	{
		public UserStateHandler() { }

        public async Task AddUserStateInDBAsync(UserStateDto userStateDto,
                                                IUserStateRepository postgresSQLUserStateRepository)
        {
            var userStateModel = new UserConverter().GetUserStateModelFromUserStateDto(userStateDto);

            try
            {
                if (userStateModel == null ||
                    String.IsNullOrWhiteSpace(userStateModel.Description) ||
                    (userStateModel.Code != ProjectEnum.EnumState.Active &&
                    userStateModel.Code != ProjectEnum.EnumState.Blocked))
                    throw new ArgumentNullException();

                var userState = new UserConverter().GetUserStateFromUserStateModel(userStateModel);

                await postgresSQLUserStateRepository.AddUserStateAsync(userState);
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

        public async Task DeleteUserStateByModelAsync(UserStateDto userStateDto,
                                                      IUserStateRepository postgresSQLUserStateRepository)
        {
            var userStateModel = new UserConverter().GetUserStateModelFromUserStateDto(userStateDto);

            try
            {
                if (userStateModel == null ||
                    String.IsNullOrWhiteSpace(userStateModel.Description) ||
                    (userStateModel.Code != ProjectEnum.EnumState.Active &&
                    userStateModel.Code != ProjectEnum.EnumState.Blocked))
                    throw new ArgumentNullException();

                var userState = new UserConverter().GetUserStateFromUserStateModel(userStateModel);

                await postgresSQLUserStateRepository.DeleteUserStateByModelAsync(userState);
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

        public async Task DeleteUserStateByCodeAsync(EnumState enumState,
                                                     IUserStateRepository postgresSQLUserStateRepository)
        {
            try
            {
                if (enumState != ProjectEnum.EnumState.Active &&
                    enumState != ProjectEnum.EnumState.Blocked)
                    throw new ArgumentNullException();

                await postgresSQLUserStateRepository.DeleteUserStateByCodeAsync(enumState);
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

        public async Task DeleteUserStateByIdAsync(long userStateId,
                                                   IUserStateRepository postgresSQLUserStateRepository)
        {
            try
            {
                if (userStateId < 0)
                    throw new ArgumentNullException();

                await postgresSQLUserStateRepository.DeleteUserStateByIdAsync(userStateId);
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

        public async Task ChangeUserStateAsync(UserStateDto userStateDto,
                                               IUserStateRepository postgresSQLUserStateRepository)
        {
            var userStateModel = new UserConverter().GetUserStateModelFromUserStateDto(userStateDto);

            try
            {
                if (userStateModel == null ||
                    String.IsNullOrWhiteSpace(userStateModel.Description) ||
                    (userStateModel.Code != ProjectEnum.EnumState.Active &&
                    userStateModel.Code != ProjectEnum.EnumState.Blocked))
                    throw new ArgumentNullException();

                var userState = new UserConverter().GetUserStateFromUserStateModel(userStateModel);

                await postgresSQLUserStateRepository.ChangeUserStateAsync(userState);
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

        public async Task<List<UserStateGetDto>> GetAllUserStateAsync(IUserStateRepository postgresSQLUserStateRepository)
        {
            try
            {
                var allUserStateModel = await postgresSQLUserStateRepository.GetAllUserStateAsync();

                return allUserStateModel.Select(x => new UserConverter().GetUserStateDtoFromUserState(x)).ToList();
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

