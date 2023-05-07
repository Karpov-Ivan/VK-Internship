using System;
using Newtonsoft.Json;
using ProjectEnum;

namespace DTOModels
{
    [JsonObject]
    public class UserGroupGetDto
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("code")]
        public EnumGroup Code { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }
    }
}

