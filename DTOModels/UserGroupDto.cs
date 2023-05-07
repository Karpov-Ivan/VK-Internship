using System;
using Newtonsoft.Json;
using ProjectEnum;

namespace DTOModels
{
    [JsonObject]
    public class UserGroupDto
    {
        [JsonProperty("code")]
        public EnumGroup Code { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }
    }
}

