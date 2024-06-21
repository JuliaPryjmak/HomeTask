#nullable enable
using Newtonsoft.Json;

namespace ApiProject.Models.Deserialize
{
    public class DLoginFail
    {
        [JsonProperty("username")]
        public string? Username { get; set; }
        [JsonProperty("failedAttemptCount")]
        public int? FailedAttemptCount { get; set; }
    }
}
