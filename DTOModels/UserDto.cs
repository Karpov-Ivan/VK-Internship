using System;
using Newtonsoft.Json;

namespace DTOModels
{
    [JsonObject]
    public class UserDto
	{
        [JsonProperty("login")]
        public string? Login { get; set; }

        [JsonProperty("password")]
        public string? Password { get; set; }

        [JsonProperty("user_group_id")]
        public long User_Group_Id { get; set; }
    }
}

