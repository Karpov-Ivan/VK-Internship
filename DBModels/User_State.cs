using System;
using ProjectEnum;

namespace DBModels
{
	public class User_State
	{
		public long Id { get; set; }

        public EnumState Code { get; set; }

        public string? Description { get; set; }
    }
}

