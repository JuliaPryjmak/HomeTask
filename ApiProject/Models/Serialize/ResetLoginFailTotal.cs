using Newtonsoft.Json;

namespace ApiProject.Models.Serialize
{
    public class SResetLoginFailTotal
    {
        [JsonProperty("username")]
        public string Username { get; set; }
    }
}
