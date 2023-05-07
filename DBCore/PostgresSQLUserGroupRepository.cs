using System;
using DBModels;
using ProjectModels;

namespace DBCore
{
	public class PostgresSQLUserGroupRepository : BaseRepository, IUserGroupRepository
    {
		public PostgresSQLUserGroupRepository(Context context) : base(context) { }

        public void AddUserGroup(User_Group user)
        {
            try
            {

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}

