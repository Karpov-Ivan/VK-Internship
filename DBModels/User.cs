using System;
namespace DBModels
{
	public class User
	{
		public long Id { get; set; }

		public string? Login { get; set; }

		public string? Password { get; set; }

		public DateTime Created_Date { get; set; }

		public long User_Group_Id { get; set; }

		public long User_State_Id { get; set; }
	}
}

