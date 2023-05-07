using System;
using Newtonsoft.Json;
using ProjectEnum;

namespace DTOModels
{
    [JsonObject]
    public class UserStateGetDto
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("code")]
        public EnumState Code { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }
    }
}

