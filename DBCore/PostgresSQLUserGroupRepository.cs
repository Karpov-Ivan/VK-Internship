﻿using System;
using System.Linq;
using DBModels;
using ProjectEnum;
using ProjectModels;

namespace DBCore
{
	public class PostgresSQLUserGroupRepository : BaseRepository, IUserGroupRepository
    {
		public PostgresSQLUserGroupRepository(Context context) : base(context) { }

        public async Task AddUserGroup(User_Group userGroup)
        {
            try
            {
                if (userGroup == null)
                    throw new ArgumentNullException();

                if (_context.User_Group.Select(x => x.Code).ToList().Contains(userGroup.Code))
                    throw new DuplicateWaitObjectException();

                await _context.AddAsync(userGroup);
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

        public async Task DeleteUserGroupByModel(User_Group userGroup)
        {
            try
            {
                if (userGroup == null)
                    throw new ArgumentNullException();

                if (!_context.User_Group.Select(x => x.Code).ToList().Contains(userGroup.Code))
                    throw new ArgumentNullException();
                var userGroupDb = _context.User_Group.First(x => x.Code == userGroup.Code &&
                                                                 x.Description == userGroup.Description);

                _context.Remove(userGroupDb);
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

        public async Task DeleteUserGroupByCode(EnumGroup enumGroup)
        {
            try
            {
                var user_group = _context.User_Group.First(x => x.Code == enumGroup);

                _context.Remove(user_group);
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

        public async Task DeleteUserGroupById(long userGroupId)
        {
            try
            {
                var user_group = _context.User_Group.First(x => x.Id == userGroupId);

                _context.Remove(user_group);
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

        public async Task ChangeUserGroup(User_Group userGroup)
        {
            try
            {
                if (!_context.User_Group.Select(x => x.Code).ToList().Contains(userGroup.Code))
                    throw new ArgumentNullException();

                var userGroupDb = _context.User_Group.First(x => x.Code == userGroup.Code);

                userGroupDb.Description = userGroup.Description;

                _context.Update(userGroupDb);
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

        public async Task<List<User_Group>> GetAllUserGroup()
        {
            try
            {
                return _context.User_Group.ToList();
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

