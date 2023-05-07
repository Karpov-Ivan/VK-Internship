using System;
using Microsoft.EntityFrameworkCore;

namespace DBCore
{
	public class PostgresSQLUserRepository : BaseRepository, IUserRepository
	{
        public PostgresSQLUserRepository(Context context) : base(context) { }
    }
}

