using System;
using System.Linq;
using DBCore.Converters;
using DBModels;
using DTOModels;
using Microsoft.EntityFrameworkCore;
using ProjectEnum;
using ProjectModels;

namespace DBCore
{
	public class PostgresSQLUserRepository : BaseRepository, IUserRepository
	{
        public PostgresSQLUserRepository(Context context) : base(context) { }

        public async Task AddUser(User user)
        {
            try
            {
                if (user == null)
                    throw new ArgumentNullException();

                if (_context.Users.Select(x => x.Login).ToList().Contains(user.Login))
                    throw new DuplicateWaitObjectException();

                if (!_context.User_Group.Select(x => x.Id).ToList().Contains(user.User_Group_Id))
                    throw new ArgumentNullException();

                var admin = _context.User_Group.First(x => x.Code == EnumGroup.Admin);
                if (_context.Users.Where(x => x.User_Group_Id == admin.Id).ToList().Count() == 1 &&
                    user.User_Group_Id == admin.Id)
                    throw new ArgumentNullException();

                user.Created_Date = DateTime.Now;
                user.User_State_Id = _context.User_State.First(x => x.Code == EnumState.Active).Id;

                await _context.Users.AddAsync(user);
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

        public async Task DeleteUserByModel(User user)
        {
            try
            {
                if (user == null)
                    throw new ArgumentNullException();

                var userDb = _context.Users.First(x => x.Login == user.Login &&
                                                       x.Password == user.Password &&
                                                       x.User_Group_Id == user.User_Group_Id);

                userDb.User_State_Id = _context.User_State.First(x => x.Code == EnumState.Blocked).Id;

                _context.Users.Update(userDb);
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

        public async Task DeleteUserById(long userId)
        {
            try
            {
                var userDb = _context.Users.First(x => x.Id == userId);

                userDb.User_State_Id = _context.User_State.First(x => x.Code == EnumState.Blocked).Id;

                _context.Users.Update(userDb);
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

        public async Task<List<UserGetModel>> GetAllUser()
        {
            try
            {
                var users = _context.Users.ToList();

                var userGetModel = new List<UserGetModel>();
                foreach (var user in users)
                {
                    var user_group = _context.User_Group.First(x => x.Id == user.User_Group_Id);

                    var user_state = _context.User_State.First(x => x.Id == user.User_State_Id);

                    userGetModel.Add(new UserConverter().GetUserGetModelFromUser(user, user_group, user_state));
                }

                return userGetModel;
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

        public async Task<List<UserGetModel>> GetMultipleUser(int count)
        {
            try
            {
                var users = _context.Users.Take(count).ToList();

                var userGetModel = new List<UserGetModel>();
                foreach (var user in users)
                {
                    var user_group = _context.User_Group.First(x => x.Id == user.User_Group_Id);

                    var user_state = _context.User_State.First(x => x.Id == user.User_State_Id);

                    userGetModel.Add(new UserConverter().GetUserGetModelFromUser(user, user_group, user_state));
                }

                return userGetModel;
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

