using ProjectEnum;

namespace ProjectModels
{
    public class UserModel
    {
        public long Id { get; set; }

        public string? Login { get; set; }

        public string? Password { get; set; }

        public DateTime Created_Date { get; set; }

        public EnumGroup Code_Group { get; set; }

        public string? Description_Group { get; set; }

        public EnumState Code_State { get; set; }

        public string? Description_State { get; set; }
    }
}

