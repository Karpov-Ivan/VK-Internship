using System;
using System.Linq;
using DBModels;
using ProjectEnum;

namespace DBCore
{
	public class PostgresSQLUserStateRepository : BaseRepository, IUserStateRepository
    {
		public PostgresSQLUserStateRepository(Context context) : base(context) { }

        public async Task AddUserStateAsync(User_State userState)
        {
            try
            {
                if (userState == null)
                    throw new ArgumentNullException();

                if (_context.User_State.Select(x => x.Code).ToList().Contains(userState.Code))
                    throw new DuplicateWaitObjectException();

                await _context.User_State.AddAsync(userState);
                await _context.SaveChangesAsync();
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

        public async Task DeleteUserStateByModelAsync(User_State userState)
        {
            try
            {
                if (userState == null)
                    throw new ArgumentNullException();

                if (!_context.User_State.Select(x => x.Code).ToList().Contains(userState.Code))
                    throw new ArgumentNullException();

                var userStateDb = _context.User_State.First(x => x.Code == userState.Code &&
                                                                 x.Description == userState.Description);

                _context.User_State.Remove(userStateDb);
                await _context.SaveChangesAsync();
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

        public async Task DeleteUserStateByCodeAsync(EnumState enumState)
        {
            try
            {
                var user_state = _context.User_State.First(x => x.Code == enumState);

                _context.User_State.Remove(user_state);
                await _context.SaveChangesAsync();
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

        public async Task DeleteUserStateByIdAsync(long userStateId)
        {
            try
            {
                var user_state = _context.User_State.First(x => x.Id == userStateId);

                _context.User_State.Remove(user_state);
                await _context.SaveChangesAsync();
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

        public async Task ChangeUserStateAsync(User_State userState)
        {
            try
            {
                if (!_context.User_State.Select(x => x.Code).ToList().Contains(userState.Code))
                    throw new ArgumentNullException();

                var userStateDb = _context.User_State.First(x => x.Code == userState.Code);

                userStateDb.Description = userState.Description;

                _context.User_State.Update(userStateDb);
                await _context.SaveChangesAsync();
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

        public async Task<List<User_State>> GetAllUserStateAsync()
        {
            try
            {
                return _context.User_State.ToList();
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

