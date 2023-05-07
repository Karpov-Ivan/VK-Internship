using System;
namespace DBCore
{
	public class PostgresSQLUserStateRepository : BaseRepository, IUserStateRepository
    {
		public PostgresSQLUserStateRepository(Context context) : base(context) { }
    }
}

