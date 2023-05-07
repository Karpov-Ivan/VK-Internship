using System;
using ProjectEnum;

namespace DBModels
{
	public class User_Group
	{
		public long Id { get; set; }

		public EnumGroup Code { get; set; }

		public string? Description { get; set; }
	}
}

