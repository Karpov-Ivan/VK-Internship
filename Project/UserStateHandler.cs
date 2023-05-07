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

        public async Task AddUserStateInDB(UserStateDto userStateDto,
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

                await postgresSQLUserStateRepository.AddUserState(userState);
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

        public async Task DeleteUserStateByModel(UserStateDto userStateDto,
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

                await postgresSQLUserStateRepository.DeleteUserStateByModel(userState);
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

        public async Task DeleteUserStateByCode(EnumState enumState,
                                                IUserStateRepository postgresSQLUserStateRepository)
        {
            try
            {
                if (enumState != ProjectEnum.EnumState.Active &&
                    enumState != ProjectEnum.EnumState.Blocked)
                    throw new ArgumentNullException();

                await postgresSQLUserStateRepository.DeleteUserStateByCode(enumState);
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

        public async Task DeleteUserStateById(long userStateId,
                                              IUserStateRepository postgresSQLUserStateRepository)
        {
            try
            {
                if (userStateId < 0)
                    throw new ArgumentNullException();

                await postgresSQLUserStateRepository.DeleteUserStateById(userStateId);
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

        public async Task ChangeUserState(UserStateDto userStateDto,
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

                await postgresSQLUserStateRepository.ChangeUserState(userState);
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

        public async Task<List<UserStateGetDto>> GetAllUserState(IUserStateRepository postgresSQLUserStateRepository)
        {
            try
            {
                var allUserStateModel = await postgresSQLUserStateRepository.GetAllUserState();

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

