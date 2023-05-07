using System;
using Newtonsoft.Json;
using ProjectEnum;

namespace DTOModels
{
    [JsonObject]
    public class UserGetDto
	{
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("login")]
        public string? Login { get; set; }

        [JsonProperty("password")]
        public string? Password { get; set; }

        [JsonProperty("created_date")]
        public DateTime Created_Date { get; set; }

        [JsonProperty("code_group")]
        public EnumGroup Code_Group { get; set; }

        [JsonProperty("description_group")]
        public string? Description_Group { get; set; }

        [JsonProperty("code_state")]
        public EnumState Code_State { get; set; }

        [JsonProperty("description_state")]
        public string? Description_State { get; set; }
    }
}

