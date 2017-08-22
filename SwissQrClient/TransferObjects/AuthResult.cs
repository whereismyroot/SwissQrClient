using Newtonsoft.Json;

namespace SwissQrClient.TransferObjects
{
    public class AuthResult
    {
        [JsonProperty("errors")]
        public bool Errors { get; set; }

        [JsonProperty("data")]
        public AuthenticationData<UserSimpleDto> Data { get; set; }
    }
}
