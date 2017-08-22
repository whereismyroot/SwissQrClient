using Newtonsoft.Json;

namespace SwissQrClient.TransferObjects.RequestParameters
{
    public class RegisterUserDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("password_confirmation")]
        public string PasswordConfirmation { get; set; }
    }
}
