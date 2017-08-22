using Newtonsoft.Json;

namespace SwissQrClient.TransferObjects
{
    public class AuthenticationData<TUser>
    {
        [JsonProperty("user")]
        public TUser User { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
